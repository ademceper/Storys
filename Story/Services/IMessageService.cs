using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using Story.Data;


namespace Story.Services;

public interface IMessageService
{
    void Send();

}
public class MessageService : IMessageService
{
    private readonly AppDbContext context;
    private readonly IEmailService emailService;
    private readonly UserManager<AppUser> userManager;

    public MessageService(AppDbContext context, IEmailService emailService, UserManager<AppUser> userManager)
    {
        this.context = context;
        this.emailService = emailService;
        this.userManager = userManager;
    }
    public void Send()
    {
        var currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
        var messages = context.EMails.Where(p => p.Enabled).ToList();
        var users = userManager.Users.ToList();
        foreach (var message in messages)
        {
            if (DateTime.Today.Add(message.Time) == currentDate)
            {
                foreach (var user in users)
                {

                    emailService.Send(user.UserName, message.Subject, message.Body, isHtml: true);

                }
            }
        }

    }
}