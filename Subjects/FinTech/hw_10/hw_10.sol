const { expect } = require("chai");
const { ethers } = require("hardhat");

let guessNumber, lottery;
let owner, user1, user2;

describe("Contracts", () => {
  beforeEach(async () => {
    [owner, user1, user2, ...rest] = await ethers.getSigners();

    const GuessNumber = await ethers.getContractFactory("GuessNumber");
    guessNumber = await GuessNumber.deploy();
    await guessNumber.deployed();

    const Lottery = await ethers.getContractFactory("Lottery");
    lottery = await Lottery.deploy();
    await lottery.deployed();
  });

  describe("GuessNumber", () => {
    it("owner sets value", async () => {
      await guessNumber.setSecretNumber(42);
      const val = await guessNumber.secretNumber();
      expect(val).to.equal(42);
    });

    it("correct guess triggers event", async () => {
      await guessNumber.setSecretNumber(42);
      await expect(guessNumber.connect(user1).guessNumber(42))
        .to.emit(guessNumber, "CorrectGuess");
    });

    it("wrong guess triggers event", async () => {
      await guessNumber.setSecretNumber(42);
      await expect(guessNumber.connect(user1).guessNumber(17))
        .to.emit(guessNumber, "IncorrectGuess");
    });
  });

  describe("Lottery", () => {
    it("ticket purchase increases count", async () => {
      await lottery.connect(user1).buyTicket({ value: ethers.utils.parseEther("1") });
      const count = await lottery.getTicketCount();
      expect(count).to.equal(1);
    });

    it("winner selected from buyers", async () => {
      await lottery.connect(user1).buyTicket({ value: ethers.utils.parseEther("1") });
      await lottery.connect(user2).buyTicket({ value: ethers.utils.parseEther("1") });

      await lottery.drawWinner();
      const selected = await lottery.winner();
      expect([user1.address, user2.address]).to.include(selected);
    });

    it("rejects draw if no tickets", async () => {
      await expect(lottery.drawWinner())
        .to.be.revertedWith("No tickets purchased");
    });
  });
});
