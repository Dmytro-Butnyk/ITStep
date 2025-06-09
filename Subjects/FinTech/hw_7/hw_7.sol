// SPDX-License-Identifier: MIT
pragma solidity ^0.8.17;

contract Lottery {
    address public immutable creator;
    address[] private participants;
    uint private pool;
    bool private isRunning;

    event Started();
    event Joined(address indexed participant, uint amount);
    event Finished(address indexed winner, uint reward);

    modifier onlyCreator() {
        require(msg.sender == creator, "Access denied");
        _;
    }

    constructor() {
        creator = msg.sender;
        isRunning = true;
    }

    function join() external payable {
        require(isRunning, "Lottery closed");
        require(msg.value > 0, "Zero value");

        participants.push(msg.sender);
        pool += msg.value;

        emit Joined(msg.sender, msg.value);
    }

    function draw() external onlyCreator {
        require(isRunning, "Already drawn");
        require(participants.length > 0, "No entries");

        uint idx = uint(
            keccak256(
                abi.encodePacked(block.timestamp, block.prevrandao, participants)
            )
        ) % participants.length;

        address winner = participants[idx];
        uint payout = (pool * 90) / 100;

        payable(winner).transfer(payout);
        payable(creator).transfer(address(this).balance);

        emit Finished(winner, payout);

        _clear();
    }

    function _clear() private {
        delete participants;
        pool = 0;
        isRunning = true;
    }
}
