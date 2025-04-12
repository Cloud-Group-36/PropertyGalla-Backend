using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyGalla.Data;

namespace PropertyGalla.Services
{
    public class IdGeneratorService
    {
        private readonly PropertyGallaContext _context;

        public IdGeneratorService(PropertyGallaContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateIdAsync(string tableName)
        {
            string prefix = GetPrefix(tableName);
            if (prefix == null)
                throw new ArgumentException("Invalid table name or prefix not defined.");

            int nextNumber = 1;

            switch (tableName.ToLower())
            {
                case "users":
                    var lastUser = await _context.Users.OrderByDescending(u => u.UserId).FirstOrDefaultAsync();
                    if (lastUser != null)
                        nextNumber = ExtractNumber(lastUser.UserId, prefix) + 1;
                    break;

                case "properties":
                    var lastProperty = await _context.Properties.OrderByDescending(p => p.PropertyId).FirstOrDefaultAsync();
                    if (lastProperty != null)
                        nextNumber = ExtractNumber(lastProperty.PropertyId, prefix) + 1;
                    break;


                case "viewrequests":
                    var lastRequest = await _context.ViewRequests.OrderByDescending(r => r.RequestId).FirstOrDefaultAsync();
                    if (lastRequest != null)
                        nextNumber = ExtractNumber(lastRequest.RequestId, prefix) + 1;
                    break;

                case "contactmessages":
                    var lastMessage = await _context.ContactMessages.OrderByDescending(m => m.MessageId).FirstOrDefaultAsync();
                    if (lastMessage != null)
                        nextNumber = ExtractNumber(lastMessage.MessageId, prefix) + 1;
                    break;

                case "feedback":
                    var lastFeedback = await _context.Feedbacks.OrderByDescending(f => f.FeedbackId).FirstOrDefaultAsync();
                    if (lastFeedback != null)
                        nextNumber = ExtractNumber(lastFeedback.FeedbackId, prefix) + 1;
                    break;

                case "reports":
                    var lastReport = await _context.Reports.OrderByDescending(r => r.ReportId).FirstOrDefaultAsync();
                    if (lastReport != null)
                        nextNumber = ExtractNumber(lastReport.ReportId, prefix) + 1;
                    break;

                default:
                    throw new ArgumentException("Unknown table");
            }

            return $"{prefix}{nextNumber.ToString("D4")}";
        }

        private string GetPrefix(string tableName)
        {
            return tableName.ToLower() switch
            {
                "users" => "USE",
                "properties" => "PRO",
                "usercart" => "CRT",
                "viewrequests" => "VRQ",
                "contactmessages" => "MSG",
                "feedback" => "FED",
                "reports" => "REP",
                _ => null
            };
        }

        private int ExtractNumber(string id, string prefix)
        {
            if (id.StartsWith(prefix))
            {
                var numberPart = id.Substring(prefix.Length);
                return int.TryParse(numberPart, out int num) ? num : 0;
            }
            return 0;
        }
    }
}
