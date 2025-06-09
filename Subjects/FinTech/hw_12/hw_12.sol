// SPDX-License-Identifier: MIT
pragma solidity ^0.8.17;

import "@openzeppelin/contracts/token/ERC20/IERC20.sol";
import "@openzeppelin/contracts/access/Ownable.sol";

contract TokenVote is Ownable {
    IERC20 public token;
    uint256 public minVotes;

    struct Poll {
        string text;
        uint256 yes;
        uint256 no;
        uint256 launched;
        uint256 period;
        bool closed;
        mapping(address => bool) hasVoted;
    }

    Poll[] private polls;

    event Opened(uint256 id, string text);
    event Participated(uint256 id, address who, bool support, uint256 power);
    event Closed(uint256 id);

    modifier onlyHolder() {
        require(token.balanceOf(msg.sender) > 0, "No tokens");
        _;
    }

    constructor(address tokenAddr, uint256 threshold) Ownable(msg.sender) {
        token = IERC20(tokenAddr);
        minVotes = threshold;
    }

    function open(string calldata text, uint256 timeLimit) external onlyHolder {
        polls.push();
        Poll storage p = polls[polls.length - 1];
        p.text = text;
        p.launched = block.timestamp;
        p.period = timeLimit;
        emit Opened(polls.length - 1, text);
    }

    function participate(uint256 id, bool agree) external onlyHolder {
        require(id < polls.length, "Bad ID");
        Poll storage p = polls[id];
        require(!p.hasVoted[msg.sender], "Voted");
        require(!p.closed, "Closed");
        require(block.timestamp <= p.launched + p.period, "Expired");

        uint256 power = token.balanceOf(msg.sender);
        p.hasVoted[msg.sender] = true;

        if (agree) {
            p.yes += power;
        } else {
            p.no += power;
        }

        emit Participated(id, msg.sender, agree, power);
    }

    function close(uint256 id) external onlyOwner {
        require(id < polls.length, "Bad ID");
        Poll storage p = polls[id];
        require(!p.closed, "Already closed");
        require(block.timestamp > p.launched + p.period, "Still open");

        uint256 total = p.yes + p.no;
        require(total >= minVotes, "Not enough votes");

        p.closed = true;
        emit Closed(id);
    }

    function viewPoll(uint256 id) external view returns (
        string memory text,
        uint256 yes,
        uint256 no,
        uint256 launched,
        uint256 period,
        bool done
    ) {
        require(id < polls.length, "Bad ID");
        Poll storage p = polls[id];
        return (p.text, p.yes, p.no, p.launched, p.period, p.closed);
    }
}
