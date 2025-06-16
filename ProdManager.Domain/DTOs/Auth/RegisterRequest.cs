﻿namespace ProdManager.Application.DTOs.Auth;

public class RegisterRequest
{
    public int Registration { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}