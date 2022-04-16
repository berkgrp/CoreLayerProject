using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRecaptchaValidator
    {
        Task<bool> RecaptchaVerifyAsync(string token);
    }
}
