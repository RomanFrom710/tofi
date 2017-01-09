﻿using System.Web.Mvc;
using BLL.Services.Security;
using Microsoft.AspNet.Identity;

namespace TOFI.Web.Auth
{
    public class CustomPasswordHasher : IPasswordHasher
    {
        private readonly ISecurityService _securityService;


        public CustomPasswordHasher()
        {
            _securityService = DependencyResolver.Current.GetService<ISecurityService>();
        }


        public string HashPassword(string password)
        {
            var salt = _securityService.GetNewSalt().Value;
            var passwordHash = _securityService.ApplySalt(password, salt);
            return $"{passwordHash} {salt}";
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var passwordParts = hashedPassword.Split(' ');
            var passwordHash = _securityService.ApplySalt(providedPassword, passwordParts[1]).Value;
            return passwordParts[0] == passwordHash
                ? PasswordVerificationResult.Success
                : PasswordVerificationResult.Failed;
        }
    }
}