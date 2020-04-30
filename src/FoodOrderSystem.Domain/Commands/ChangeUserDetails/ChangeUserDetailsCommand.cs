﻿using FoodOrderSystem.Domain.Model.User;
using FoodOrderSystem.Domain.ViewModels;

namespace FoodOrderSystem.Domain.Commands.ChangeUserDetails
{
    public class ChangeUserDetailsCommand : ICommand<bool>
    {
        public ChangeUserDetailsCommand(UserId userId, string name, Role role, string email)
        {
            UserId = userId;
            Name = name;
            Role = role;
            Email = email;
        }

        public UserId UserId { get; }
        public string Name { get; }
        public Role Role { get; }
        public string Email { get; }
    }
}
