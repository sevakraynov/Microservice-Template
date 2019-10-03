﻿using System;
using System.Security.Claims;
using Calabonga.Microservice.IdentityModule.Data;
using Calabonga.Microservice.IdentityModule.Web.Infrastructure.Auth;
using Calabonga.Microservice.IdentityModule.Web.Infrastructure.Mappers.Base;
using Calabonga.Microservice.IdentityModule.Web.Infrastructure.ViewModels.AccountViewModels;
using IdentityModel;

namespace Calabonga.Microservice.IdentityModule.Web.Infrastructure.Mappers
{
    /// <summary>
    /// Mapper Configuration for entity ApplicationUser
    /// </summary>
    public class ApplicationUserMapperConfiguration : MapperConfigurationBase
    {
        /// <inheritdoc />
        public ApplicationUserMapperConfiguration()
        {
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(x => x.UserName, o => o.MapFrom(p => p.Email))
                .ForMember(x => x.Email, o => o.MapFrom(p => p.Email))
                .ForMember(x => x.EmailConfirmed, o => o.MapFrom(src => true))
                .ForMember(x => x.FirstName, o => o.MapFrom(p => p.FirstName))
                .ForMember(x => x.LastName, o => o.MapFrom(p => p.LastName))
                .ForMember(x => x.PhoneNumberConfirmed, o => o.MapFrom(src => true))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<ClaimsIdentity, ApplicationUserProfileViewModel>()
                .ForMember(x => x.Id, o => o.MapFrom(claims => ClaimsHelper.GetValue<Guid>(claims, JwtClaimTypes.Subject)))
                .ForMember(x => x.PositionName, o => o.MapFrom(claims => ClaimsHelper.GetValue<string>(claims, ClaimTypes.Actor)))
                .ForMember(x => x.FirstName, o => o.MapFrom(claims => ClaimsHelper.GetValue<string>(claims, JwtClaimTypes.GivenName)))
                .ForMember(x => x.LastName, o => o.MapFrom(claims => ClaimsHelper.GetValue<string>(claims, ClaimTypes.Surname)))
                .ForMember(x => x.Roles, o => o.MapFrom(claims => ClaimsHelper.GetValues<string>(claims, JwtClaimTypes.Role)))
                .ForMember(x => x.Email, o => o.MapFrom(claims => ClaimsHelper.GetValue<string>(claims, JwtClaimTypes.Name)))
                .ForMember(x => x.PhoneNumber, o => o.MapFrom(claims => ClaimsHelper.GetValue<string>(claims, JwtClaimTypes.PhoneNumber)))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
