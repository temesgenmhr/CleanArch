using CleanArch.Application.Model.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Contracts.Infrastructure
{
   public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
