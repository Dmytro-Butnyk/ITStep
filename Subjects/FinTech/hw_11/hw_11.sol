// SPDX-License-Identifier: MIT
pragma solidity ^0.8.17;

contract BoardVote {
    address public admin;

    struct Item {
        string text;
        uint256 yes;
        uint256 no;
        uint256 timestamp;
        bool done;
        mapping(address => bool) voters;
    }

    Item[] private items;
    mapping(address => bool) private members;

    event NewItem(uint256 id, string text);
    event Voted(uint256 id, address by, bool choice);
    event Finalized(uint256 id);

    modifier onlyAdmin() {
        require(msg.sender == admin, "Not admin");
        _;
    }

    modifier memberOnly() {
        require(members[msg.sender], "Access denied");
        _;
    }

    constructor(address[] memory board) {
        admin = msg.sender;
        for (uint i = 0; i < board.length; i++) {
            members[board[i]] = true;
        }
    }

    function propose(string calldata text) external memberOnly {
        items.push();
        Item storage i = items[items.length - 1];
        i.text = text;
        i.timestamp = block.timestamp;
        emit NewItem(items.length - 1, text);
    }

    function vote(uint id, bool approve) external memberOnly {
        require(id < items.length, "Invalid ID");
        Item storage i = items[id];
        require(!i.voters[msg.sender], "Already voted");
        require(!i.done, "Closed");

        i.voters[msg.sender] = true;
        approve ? i.yes++ : i.no++;

        emit Voted(id, msg.sender, approve);
    }

    function finalize(uint id) external onlyAdmin {
        require(id < items.length, "Invalid ID");
        Item storage i = items[id];
        require(!i.done, "Already done");

        i.done = true;
        emit Finalized(id);
    }

    function viewItem(uint id) external view returns (
        string memory text,
        uint256 yes,
        uint256 no,
        uint256 timestamp,
        bool closed
    ) {
        require(id < items.length, "Invalid ID");
        Item storage i = items[id];
        return (i.text, i.yes, i.no, i.timestamp, i.done);
    }
}
