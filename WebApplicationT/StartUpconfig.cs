using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WebApplicationT;

public static class StartUpconfig
{
    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication("Bearer")
.AddJwtBearer(opts =>
{
    opts.IncludeErrorDetails = true;
    opts.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
        ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Authentication:SecretKey")!))

    };

});
       builder.Services.AddAuthorization(builder =>
       {
        //    builder.AddPolicy("Must be admin", p =>

        //    {
        //        p.RequireClaim("Titel", ConstentS.admin);

        //    }
          //  );
           builder.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
       });
    }
    public static void AddSwaggerSer(this WebApplicationBuilder builder)

    {
        var sDatd =new OpenApiSecurityScheme() { 

    Name = "Auth",

            Description = "jwt token",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "jwt"
        };
        var securityReqremnts = new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "authBear"
                    }
                },
                new string[] { }
            },
        };
    builder.Services.AddSwaggerGen(s=>
     {
         s.AddSecurityDefinition("authBear", sDatd);
         s.AddSecurityRequirement(securityReqremnts);
     });



}
}