using Core.Entities;
using System.Linq;

namespace Core
{
    public static class Mapper
    {
        private static Category[] categories = new[]
            {
                new Category
                {
                    Id = (int)ComplaintCategory.Policja,
                    Title = "Policja"
                },
                new Category
                {
                    Id = (int)ComplaintCategory.NadzorBudowlany,
                    Title = "Nadzór Budowlany"
                },
                new Category
                {
                    Id = (int)ComplaintCategory.StrazMiejska,
                    Title = "Straż Miejska"
                },
                new Category
                {
                    Id = (int)ComplaintCategory.UrzadSkarbowy,
                    Title = "Urząd Skarbowy"
                },
                new Category
                {
                    Id = (int)ComplaintCategory.GlownyInspektoratSanitarny,
                    Title = "Główny Inspektorat Sanitarny"
                },
                new Category
                {
                    Id = (int)ComplaintCategory.PanstwowaInspekcjaPracy,
                    Title = "Państwowa Inspekcja Pracy"
                },
                new Category
                {
                    Id = (int)ComplaintCategory.MiejskiOsrodekPomocySpolecznej,
                    Title = "Miejski Ośrodek Pomocy Społecznej"
                }
            };

        public static Category CategoryString(ComplaintCategory category)
        {
            return categories.First(x => x.Id==((int)category));
        }

        public static string UserComplaintStatus(DetailedComplaintStatus status)
        {
            return status switch
            {
                DetailedComplaintStatus.Pending => "Pending",
                DetailedComplaintStatus.Canceled => "Canceled",
                DetailedComplaintStatus.Assigned => "InProgress",
                DetailedComplaintStatus.Rejected => "Finished",
                DetailedComplaintStatus.InProgress => "InProgress",
                DetailedComplaintStatus.Finished => "Finished",
                _ => "error"
            };
        }

        public static string OfficialComplaintStatus(DetailedComplaintStatus status)
        {
            return status switch
            {
                DetailedComplaintStatus.Pending => "Pending",
                DetailedComplaintStatus.Canceled => "Canceled",
                DetailedComplaintStatus.Assigned => "Assigned",
                DetailedComplaintStatus.Rejected => "Rejected",
                DetailedComplaintStatus.InProgress => "InProgress",
                DetailedComplaintStatus.Finished => "Finished",
                _ => "error"
                
            };
        }
    }
}
