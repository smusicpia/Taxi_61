using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Plugin.Geolocator.Abstractions;

using Taxi.Web.Data.Entities;

using Taxi_Qualifier.Common.Enums;
using Taxi_Qualifier.Web.Data.Entities;
using Taxi_Qualifier.Web.Helpers;

namespace Taxi_Qualifier.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext, IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            _ = await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Juan", "Zuluaga", "jzuluaga55@gmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Admin);
            var driver = await CheckUserAsync("2020", "Juan", "Zuluaga", "jzuluaga55@hotmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Driver);
            var user1 = await CheckUserAsync("3030", "Juan", "Zuluaga", "carlos.zuluaga@globant.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            var user2 = await CheckUserAsync("4040", "Juan", "Zuluaga", "juanzuluaga2480@correo.itm.edu.co", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            await CheckTaxisAsync(driver, user1, user2);
        }

        private async Task<UserEntity> CheckUserAsync(string document, string firstName, string lastName, string email,
                                                      string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Driver.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckTaxisAsync(UserEntity driver, UserEntity user1, UserEntity user2)
        {
            if (!_dataContext.Taxis.Any())
            {
                _ = _dataContext.Taxis.Add(new TaxiEntity
                {
                    User = driver,
                    Plaque = "TPQ123",
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin blandit magna magna, nec rutrum nulla pretium quis. Aliquam a nibh non metus hendrerit efficitur ac sit amet lorem. Vivamus sollicitudin imperdiet felis vel rutrum. Curabitur eros est, vulputate non interdum pellentesque, volutpat ut nunc. Nunc tempus massa consectetur fermentum tempor. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec at orci at nisl volutpat fermentum tempor ut nulla. Nulla feugiat, sem a eleifend mollis, erat magna faucibus sapien, eu vulputate odio ipsum non orci. Donec a imperdiet tortor. Suspendisse hendrerit justo vel libero pretium, vitae gravida enim commodo. Curabitur scelerisque, nibh in pellentesque bibendum, dui velit semper odio, mollis aliquam turpis turpis in lacus. Donec in sapien ut dui vehicula faucibus. Phasellus nec sem magna. Curabitur vestibulum varius iaculis.",
                            User = user1
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Aliquam in ullamcorper orci. In sem purus, porttitor quis fermentum in, convallis sit amet dui. Proin sed diam purus. Quisque odio quam, luctus quis leo sit amet, sagittis rhoncus lacus. Maecenas auctor congue lacus a lobortis. Phasellus eget rhoncus nunc. Quisque elementum suscipit sem, eget venenatis urna placerat vel. Quisque malesuada venenatis felis, non condimentum urna convallis vel.",
                            User = user1
                        }
                    }
                });

                _ = _dataContext.Taxis.Add(new TaxiEntity
                {
                    Plaque = "THW321",
                    User = driver,
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Muy buen servicio",
                            User = user2
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Conductor muy amable",
                            User = user2
                        }
                    }
                });

                _ = await _dataContext.SaveChangesAsync();
            }
        }
    }
}