﻿using HexagonalTemplate.Cores;
using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using Xunit.Sdk;

namespace HexagonalTemplate.Test.CoreTests
{
    public class UserCoreTests
    {
        private readonly IUserCore userCore;

        public UserCoreTests()
        {
            userCore = new UserCore();
        }

        private UserEntity CreateUserEntity(string email, string password)
        {
            return new UserEntity
            {
                Email = email,
                Password = password
            };
        }

        [Fact]
        public void ValidateUser_ValidUserEntity_NoExceptionThrown()
        {
            // Arrange
            var userEntity = CreateUserEntity("test@example.com", "Password123");

            // Act
            Action act = () =>
            {
                try
                {
                    userCore.ValidateUser(userEntity);
                }
                catch (Exception ex)
                {
                    throw new XunitException($"Expected no exception to be thrown, but found {ex.GetType()}: \"{ex.Message}\"");
                }
            };

            // Assert
            act.Invoke();
        }

        [Fact]
        public void ValidateUserAndValidatePassword_NullUserEntity_ThrowsArgumentNullException()
        {
            // Arrange
            UserEntity userEntity = null;

            // Act
            Action validateUserAction = () =>
            {
                try
                {
                    userCore.ValidateUser(userEntity);
                }
                catch (ArgumentNullException ex)
                {
                    if (ex.ParamName != "userEntity")
                    {
                        throw new XunitException($"Expected ArgumentNullException with parameter name \"userEntity\", but found \"{ex.ParamName}\"");
                    }
                    return;
                }
                throw new XunitException("Expected ArgumentNullException with parameter name \"userEntity\", but no exception was thrown");
            };

            Action validatePasswordAction = () =>
            {
                try
                {
                    userCore.ValidatePassword(userEntity);
                }
                catch (ArgumentNullException ex)
                {
                    if (ex.ParamName != "userEntity")
                    {
                        throw new XunitException($"Expected ArgumentNullException with parameter name \"userEntity\", but found \"{ex.ParamName}\"");
                    }
                    return;
                }
                throw new XunitException("Expected ArgumentNullException with parameter name \"userEntity\", but no exception was thrown");
            };

            // Assert
            validateUserAction.Invoke();
            validatePasswordAction.Invoke();
        }

        [Theory]
        [InlineData("Pass123")] // Less than 8 characters
        [InlineData("password")] // No uppercase letter
        [InlineData("PASSWORD")] // No lowercase letter
        [InlineData("12345678")] // No special character
        public void ValidatePassword_InvalidPassword_ThrowsArgumentException(string password)
        {
            // Arrange
            var userEntity = CreateUserEntity("test@example.com", password);

            // Act
            Action act = () =>
            {
                try
                {
                    userCore.ValidatePassword(userEntity);
                }
                catch (ArgumentException ex)
                {
                    if (ex.ParamName != "userEntity")
                    {
                        throw new XunitException($"Expected ArgumentException with parameter name \"userEntity\", but found \"{ex.ParamName}\"");
                    }
                    return;
                }
                throw new XunitException("Expected ArgumentException with parameter name \"userEntity\", but no exception was thrown");
            };

            // Assert
            act.Invoke();
        }

        [Fact]
        public void ValidatePassword_ValidPassword_NoExceptionThrown()
        {
            // Arrange
            var userEntity = CreateUserEntity("test@example.com", "Password123!");

            // Act
            Action act = () =>
            {
                try
                {
                    userCore.ValidatePassword(userEntity);
                }
                catch (Exception ex)
                {
                    throw new XunitException($"Expected no exception to be thrown, but found {ex.GetType()}: \"{ex.Message}\"");
                }
            };

            // Assert
            act.Invoke();
        }
    }
}