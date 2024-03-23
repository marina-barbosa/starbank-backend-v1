using StarBank.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using StarBank.Domain.DTOs;

namespace StarBank.Controllers;

[ApiController] 
[Route("starBank")]

public class RegisterAccountController : ControllerBase
{
    public static List<Account> accounts = new(){
        new(){
            Id = 1,
            Number = "1245-85",
            Agency = "243-2",
            AccountType = "Conta Corrente",
            Balance = 245.65,
            Password = "starbank123",
            ConfirmPassword = "starbank123"
        },
    };


    [HttpPost("register/account")]
    public IActionResult RegisterAccount(Account account){
        accounts.Add(account);

        return Ok("Account Created!");
    }

    [HttpGet("information/account")]
    public IActionResult GetAccount(){

        var accountProfiles = accounts.Select(account => new Account(){
            Id = account.Id,
            Number = account.Number,
            Agency = account.Agency,
            AccountType = account.AccountType,
            Balance = account.Balance,
            Password = account.Password,
            ConfirmPassword = account.ConfirmPassword
        });

        return Ok(accountProfiles);
    }
}