﻿using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class BLLTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllAccountsTest()
        {
            // Arrange
            var data = new[]
            {
                new BankAccountDTO(3, "Vlad", "Borovsky", 100.0m, 15, AccountType.Gold.ToString()),
                new BankAccountDTO(4, "Maw", "Flames", 260.0m, 10, AccountType.Platinum.ToString())
            };

            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetAll()).Returns(data);

            // Act
            var actual = new AccountService(mock.Object).GetAllAccounts().Count();
            var expected = data.Count();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenAccountTest()
        {
            // Arrange
            var data = new List<BankAccountDTO>();

            var account = new BankAccountDTO(1, "Some", "Body", 0.0m, 0, (AccountType.Silver).ToString());

            var mockRepository = new Mock<IRepository>();
            var mockNumberGenerator = new Mock<IAccountNumberService>();

            mockRepository.Setup(a => a.AddAccount(It.IsAny<BankAccountDTO>())).Callback(() => data.Add(account));
            mockNumberGenerator.Setup(a => a.GenerateNumber(It.IsAny<int>())).Returns(1);

            // Act
            var service = new AccountService(mockRepository.Object);
            service.OpenAccount(account.FirstName, account.LastName, AccountType.Silver, mockNumberGenerator.Object);

            var actual = data.Count;
            var expected = 1;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CloseAccountTest()
        {
            // Arrange
            var data = new List<BankAccountDTO>();

            var accountTest = new BankAccountDTO(3, "Vlad", "Borovsky", 100.0m, 15, AccountType.Gold.ToString());

            data.Add(accountTest);

            var mock = new Mock<IRepository>();
            mock.Setup(a => a.RemoveAccount(It.IsAny<BankAccountDTO>())).Callback(() => data.Remove(accountTest));

            // Act
            var service = new AccountService(mock.Object);
            service.CloseAccount(AccountMapper.DTOToAccount(accountTest));

            var actual = data.Count;
            var expected = 0;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DepositAccountTest()
        {
            // Arrange
            var data = new List<BankAccountDTO>();

            var account = new BankAccountDTO(4, "Maw", "Flames", 260.0m, 10, AccountType.Platinum.ToString());
            var expected = account.Balance;

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(a => a.UpdateAccount(It.IsAny<BankAccountDTO>())).Callback(() => account.Balance += 10.0m);

            // Act
            var service = new AccountService(mockRepository.Object);
            service.DepositAccount(AccountMapper.DTOToAccount(account), 10.0m);

            expected += 10.0m;
            var actual = account.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithdrawAccountTest()
        {
            // Arrange
            var data = new List<BankAccountDTO>();

            var account = new BankAccountDTO(4, "Maw", "Flames", 260.0m, 10, AccountType.Platinum.ToString());
            var expected = account.Balance;

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(a => a.UpdateAccount(It.IsAny<BankAccountDTO>())).Callback(() => account.Balance -= 10.0m);

            // Act
            var service = new AccountService(mockRepository.Object);
            service.WithdrawAccount(BankAccountMapper.DTOToBancAcc(account), 10.0m);

            expected -= 10.0m;
            var actual = account.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAccountByIdTest()
        {
            // Arrange
            var data = new[]
            {
                new BankAccountDTO(3, "Vlad", "Borovsky", 100.0m, 15, AccountType.Gold.ToString()),
                new BankAccountDTO(4, "Maw", "Flames", 260.0m, 10, AccountType.Platinum.ToString())
            };

            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetAll()).Returns(data);

            // Act
            var service = new AccountService(mock.Object);
            var acc = service.GetAccountById(3);
            var result = BankAccountMapper.BankAccToDTO(acc);

            string expectedAccountType = data[0].AccountType;
            string actualAccountType = result.AccountType;

            if (expectedAccountType.Substring(0, 3) != "BLL")
            {
                expectedAccountType = "BLL.Interface." + expectedAccountType + "Account";
            }

            if (actualAccountType.Substring(0, 3) != "BLL")
            {
                actualAccountType = "BLL.Interface." + actualAccountType + "Account";
            }

            // Assert
            Assert.AreEqual(data[0].Id, result.Id);
            Assert.AreEqual(data[0].FirstName, result.FirstName);
            Assert.AreEqual(data[0].LastName, result.LastName);
            Assert.AreEqual(data[0].Balance, result.Balance);
            Assert.AreEqual(expectedAccountType, actualAccountType);
            Assert.AreEqual(data[0].BonusPoints, result.BonusPoints);
        }
    }
}