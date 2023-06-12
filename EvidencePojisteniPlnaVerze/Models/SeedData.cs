using EvidencePojisteniPlnaVerze.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EvidencePojisteniPlnaVerze.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext (serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Insured.Any())
                {
                    return;
                }

                context.Insured.AddRange(
                    new Insured
                    {
                        FirstName = "Josef",
                        LastName = "Novotný",
                        Email = "novotny@gmail.com",
                        PhoneNumber = 459215483,
                        Street = "Hlavní",
                        HouseNumber = 45,
                        City = "Praha",
                        Zip = 23015,
                        Insurances = new List<Insurance>
                        {
                            new Insurance
                            {
                                TypeInsurance = "Zdravotní pojištění",
                                Amount = 100000,
                                SubjectInsurance = "Josef Novotný",
                                ValidFrom = new DateTime(2015, 10, 4),
                                ValidUntil = new DateTime(2055, 10, 4)
                            },
                            new Insurance
                            {
                                TypeInsurance = "Životní pojištění",
                                Amount = 500000,
                                SubjectInsurance = "Josef Novotný",
                                ValidFrom = new DateTime(2015, 10, 4),
                                ValidUntil = new DateTime(2055, 10, 4)
                            }
                        }
                    },
                    new Insured
                    {
                        FirstName = "Martin",
                        LastName = "Kučera",
                        Email = "martinek23@email.cz",
                        PhoneNumber = 459321159,
                        Street = "U Potoka",
                        HouseNumber = 1,
                        City = "Praha",
                        Zip = 23012,
                        Insurances = new List<Insurance>
                        {
                            new Insurance
                            {
                                TypeInsurance = "Životní pojištění",
                                Amount = 2000000,
                                SubjectInsurance = "Martin Kučera",
                                ValidFrom = new DateTime(2000, 1, 1),
                                ValidUntil = new DateTime(2050, 1, 1)
                            }
                        }
                    },
                    new Insured
                    {
                        FirstName = "Petr",
                        LastName = "Nesvadba",
                        Email = "petrnesvadba@email.cz",
                        PhoneNumber = 123123564,
                        Street = "Pražská",
                        HouseNumber = 165,
                        City = "Pardubice",
                        Zip = 14200,
                        Insurances = new List<Insurance>
                        {
                            new Insurance
                            {
                                TypeInsurance = "Pojištění majetku",
                                Amount = 750000,
                                SubjectInsurance = "Nemovitost",
                                ValidFrom = new DateTime(2020, 1, 11),
                                ValidUntil = new DateTime(2040, 1, 11)
                            }
                        }
                    }, new Insured
                    {
                        FirstName = "Marcela",
                        LastName = "Nováková",
                        Email = "novakova@seznam.cz",
                        PhoneNumber = 474741851,
                        Street = "Masarykova",
                        HouseNumber = 4,
                        City = "Brno",
                        Zip = 61200,
                        Insurances = new List<Insurance>
                        {
                            new Insurance
                            {
                                TypeInsurance = "Pojištění majetku",
                                Amount = 1000000,
                                SubjectInsurance = "Nemovitost",
                                ValidFrom = new DateTime(2010, 12, 20),
                                ValidUntil = new DateTime(2030, 12, 20)
                            },
                            new Insurance
                            {
                                TypeInsurance = "Životní pojištění",
                                Amount = 500000,
                                SubjectInsurance = "Marcela Nováková",
                                ValidFrom = new DateTime(2020, 5, 4),
                                ValidUntil = new DateTime(2030, 5, 4)
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
