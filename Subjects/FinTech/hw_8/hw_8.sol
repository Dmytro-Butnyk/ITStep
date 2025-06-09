// SPDX-License-Identifier: MIT
pragma solidity ^0.8.17;

contract NumberGame {
    address public immutable admin;
    uint256 private target;
    uint256 public betFloor;
    uint256 public baseDeposit;
    uint256 public pot;

    mapping(address => uint256) public attempts;

    event Launched(uint256 betFloor, uint256 deposit);
    event Tried(address indexed player, uint256 number, bool hit);
    event Payout(address indexed to, uint256 value);

    constructor(uint256 _betFloor) payable {
        require(msg.value > 0, "Zero deposit");

        admin = msg.sender;
        betFloor = _betFloor;
        baseDeposit = msg.value;
        pot = msg.value;

        target = uint256(
            keccak256(abi.encodePacked(block.timestamp, block.prevrandao, msg.sender))
        ) % 100 + 1;

        emit Launched(betFloor, baseDeposit);
    }

    function play(uint256 number) external payable {
        require(msg.value >= betFloor, "Low stake");

        pot += msg.value;
        attempts[msg.sender]++;

        if (number == target) {
            uint256 prize = (pot * 75) / 100;
            if (prize < baseDeposit) {
                prize = baseDeposit;
            }

            payable(msg.sender).transfer(prize);
            pot -= prize;

            emit Tried(msg.sender, number, true);
        } else {
            emit Tried(msg.sender, number, false);
        }
    }

    function skim() external {
        require(msg.sender == admin, "Denied");
        require(pot >= baseDeposit * 100, "Too early");

        uint256 take = pot / 3;
        payable(admin).transfer(take);
        pot -= take;

        emit Payout(admin, take);
    }
}
