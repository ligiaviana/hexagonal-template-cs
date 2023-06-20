//using HexagonalTemplate.Cores;
//using HexagonalTemplate.Models.Entities;
//using HexagonalTemplate.Ports.Ins;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;

//namespace HexagonalTemplate.Test.CoreTests
//{
//    public class JwtCoreTests
//    {
//        private readonly IJwtCore jwtCore;

//        public JwtCoreTests()
//        {
//            jwtCore = new JwtCore("secret_key", 60);
//        }

//        [Fact]
//        public void GenerateToken_ValidUserEntity_ReturnsTokenString()
//        {
//            // Arrange
//            var userEntity = new UserEntity
//            {
//                Email = "test@example.com"
//            };

//            // Act
//            var token = jwtCore.GenerateToken(userEntity);

//            // Assert
//            Assert.NotNull(token);
//            Assert.NotEmpty(token);
//        }

//        [Fact]
//        public void GenerateToken_ValidUserEntity_SignsTokenWithCorrectAlgorithm()
//        {
//            // Arrange
//            var userEntity = new UserEntity
//            {
//                Email = "test@example.com"
//            };

//            var tokenHandler = new JwtSecurityTokenHandler();

//            // Act
//            var token = jwtCore.GenerateToken(userEntity);
//            var jwtToken = tokenHandler.ReadJwtToken(token);

//            // Assert
//            Assert.NotNull(jwtToken);
//            Assert.IsType<JwtSecurityToken>(jwtToken);

//            var signingAlgorithm = jwtToken.Header.Alg;
//            Assert.Equal("HS256", signingAlgorithm);
//        }


//        [Fact]
//        public void GenerateToken_ValidUserEntity_SetsExpirationTime()
//        {
//            // Arrange
//            var userEntity = new UserEntity
//            {
//                Email = "test@example.com"
//            };

//            // Act
//            var token = jwtCore.GenerateToken(userEntity);
//            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

//            // Assert
//            Assert.NotNull(jwtToken);
//            Assert.True(jwtToken.ValidTo > DateTime.UtcNow);
//        }

//        [Fact]
//        public void Match_ValidPasswords_NoExceptionThrown()
//        {
//            // Arrange
//            var passwordRequest = "password123";
//            var passwordDb = "password123";

//            // Act
//            Action act = () => jwtCore.Match(passwordRequest, passwordDb);

//            // Assert
//            var exception = Record.Exception(act);
//            Assert.Null(exception);
//        }

//        [Fact]
//        public void Match_InvalidPasswords_ThrowsArgumentException()
//        {
//            // Arrange
//            var passwordRequest = "password123";
//            var passwordDb = "password456";

//            // Act
//            Action act = () => jwtCore.Match(passwordRequest, passwordDb);

//            // Assert
//            Assert.Throws<ArgumentException>(act);
//        }
//    }
//}
