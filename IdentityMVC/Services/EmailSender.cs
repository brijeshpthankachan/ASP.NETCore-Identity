using Microsoft.AspNetCore.Identity.UI.Services;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System.Diagnostics;

namespace IdentityMVC.Services;

public class EmailSender : IEmailSender
{
    public async System.Threading.Tasks.Task SendEmailAsync(string email, string subject, string htmlContent)
    {
        Configuration.Default.ApiKey["api-key"] = "Your Api Key";
        var apiInstance = new TransactionalEmailsApi();

        var SenderName = "John Doe";
        var SenderEmail = "brijeshpthankachan@proton.me";
        var Email = new SendSmtpEmailSender(SenderName, SenderEmail);
        var ToEmail = email;
        var ToName = "John Doe";
        var smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
        var To = new List<SendSmtpEmailTo> { smtpEmailTo };
        var HtmlContent = htmlContent;
        var Subject = subject;

        try
        {
            var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, HtmlContent, null, Subject);
            CreateSmtpEmail result = await apiInstance.SendTransacEmailAsync(sendSmtpEmail);
            Debug.WriteLine(result.ToJson());
            Console.WriteLine(result.ToJson());
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            Console.WriteLine(e.Message);
        }
    }
}
