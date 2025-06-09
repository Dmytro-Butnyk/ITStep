// SPDX-License-Identifier: MIT
pragma solidity ^0.8.17;

contract Petitions {
    enum Status { Discussion, Approved, Declined }

    struct Entry {
        string name;
        string details;
        uint256 pros;
        uint256 cons;
        Status state;
        bool active;
    }

    mapping(uint256 => Entry) private items;
    mapping(address => mapping(uint256 => bool)) private voters;

    uint256 public total;

    event Created(uint256 indexed id, string name);
    event Cast(uint256 indexed id, bool up, address indexed who);
    event StateChanged(uint256 indexed id, Status newState);

    modifier exists(uint256 id) {
        require(items[id].active, "Missing");
        _;
    }

    function submit(string calldata name, string calldata details) external {
        total++;
        items[total] = Entry(name, details, 0, 0, Status.Discussion, true);
        emit Created(total, name);
    }

    function vote(uint256 id, bool up) external exists(id) {
        require(!voters[msg.sender][id], "Duplicate");

        Entry storage e = items[id];

        up ? e.pros++ : e.cons++;
        voters[msg.sender][id] = true;

        emit Cast(id, up, msg.sender);
        _check(id);
    }

    function _check(uint256 id) internal {
        Entry storage e = items[id];

        if (e.pros >= 10) {
            e.state = Status.Approved;
        } else if (e.cons >= 10) {
            e.state = Status.Declined;
        }

        emit StateChanged(id, e.state);
    }

    function fetch(uint256 id) external view exists(id) returns (
        string memory name,
        string memory details,
        uint256 pros,
        uint256 cons,
        Status state
    ) {
        Entry storage e = items[id];
        return (e.name, e.details, e.pros, e.cons, e.state);
    }

    function stateOf(uint256 id) external view exists(id) returns (Status) {
        return items[id].state;
    }
}
