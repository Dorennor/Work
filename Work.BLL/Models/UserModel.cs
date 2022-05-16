﻿namespace Work.BLL.Models;

public class UserModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public bool IsLogged { get; set; }

    public override string ToString()
    {
        return $"Id={Id}, Email={Email}, Role={Role}, IsLogged={IsLogged}";
    }
}