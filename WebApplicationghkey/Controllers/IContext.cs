using System.Threading.Tasks;

namespace WebApplicationghkey.Controllers
{
    public interface IContext
    {
        object TodoItems { get; }

        Task SaveChangesAsync();
    }
}