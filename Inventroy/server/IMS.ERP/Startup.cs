using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonBLL.Helper;
using CommonDAL;
using CommonDAL.Models;
using CommonDAL.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
namespace IMSERP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("api", new OpenApiInfo { Title = "TestSweggarTwo" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input Your Bearer Token i Bearer {Your Token Here} to access API"
                });
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                         {
                            Reference= new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="Bearer",
                            Name="Bearer",
                            In=ParameterLocation.Header,
                         },
                        new List <string>()
                        }
                    });
            });

            services.Configure<IMSSetting>(Configuration.GetSection("IMSSetting"));
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<IRepository<Vendor>, Repository<Vendor>>();
            services.AddScoped<IRepository<InternalTransfer>, Repository<InternalTransfer>>();
            services.AddScoped<IRepository<ExternalTransfer>, Repository<ExternalTransfer>>();
            services.AddScoped<IRepository<BankTransfer>, Repository<BankTransfer>>();
            services.AddScoped<IRepository<BankAccount>, Repository<BankAccount>>();
            services.AddScoped<IRepository<ExternalPerson>, Repository<ExternalPerson>>();
            services.AddScoped<IRepository<Employee>, Repository<Employee>>();
            services.AddScoped<IRepository<EmployeeBasicInfo>, Repository<EmployeeBasicInfo>>();
            services.AddScoped<IRepository<EmployeeAddress>, Repository<EmployeeAddress>>();
            services.AddScoped<IRepository<EmployeeEduQual>, Repository<EmployeeEduQual>>();
            services.AddScoped<IRepository<EmployeeRefPersonDetails>, Repository<EmployeeRefPersonDetails>>();
            services.AddScoped<IRepository<EmployeeDocument>, Repository<EmployeeDocument>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Unit>, Repository<Unit>>();
            services.AddScoped<IRepository<VAT>, Repository<VAT>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Manufacturer>, Repository<Manufacturer>>();
            services.AddScoped<IRepository<ProductItem>, Repository<ProductItem>>();
            services.AddScoped<IRepository<ProductAttributeMapping>, Repository<ProductAttributeMapping>>();
            services.AddScoped<IRepository<SpecificationAttribute>, Repository<SpecificationAttribute>>();
            services.AddScoped<IRepository<SpecificationAttrValue>, Repository<SpecificationAttrValue>>();
            services.AddScoped<IRepository<Production>, Repository<Production>>();

            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Shop>, Repository<Shop>>();
            services.AddScoped<IRepository<UserCreateRequest>, Repository<UserCreateRequest>>();
            services.AddScoped<IRepository<UserType>, Repository<UserType>>();
            services.AddScoped<IRepository<Organization>, Repository<Organization>>();
            services.AddScoped<IRepository<OrganizationType>, Repository<OrganizationType>>();
            services.AddScoped<IRepository<Country>, Repository<Country>>();
            services.AddScoped<IRepository<Division>, Repository<Division>>();
            services.AddScoped<IRepository<District>, Repository<District>>();
            services.AddScoped<IRepository<DistrictUpazila>, Repository<DistrictUpazila>>();
            services.AddScoped<IRepository<DistrictPostOffice>, Repository<DistrictPostOffice>>();
            services.AddScoped<IRepository<Nationality>, Repository<Nationality>>();
            services.AddScoped<IRepository<RelationShip>, Repository<RelationShip>>();
            services.AddScoped<IRepository<Profession>, Repository<Profession>>();
            services.AddScoped<IRepository<ShiftSection>, Repository<ShiftSection>>();
            services.AddScoped<IRepository<Designation>, Repository<Designation>>();
            services.AddScoped<IRepository<Supplier>, Repository<Supplier>>();
            services.AddScoped<IRepository<Shop>, Repository<Shop>>();
            services.AddScoped<IRepository<FixedExpense>, Repository<FixedExpense>>();
            services.AddScoped<IRepository<GeneralExpense>, Repository<GeneralExpense>>();
            services.AddScoped<IRepository<SalaryPayment>, Repository <SalaryPayment>>();
            services.AddScoped<IRepository<FixedExpenseSetting>, Repository<FixedExpenseSetting>>();
            services.AddScoped<IRepository<Purchase>, Repository<Purchase>>();
            services.AddScoped<IRepository<ExpenseType>, Repository<ExpenseType>>(); 
            services.AddScoped<IRepository<ExpenseHead>, Repository<ExpenseHead>>();
            services.AddScoped<IRepository<BusinessRelative>, Repository<BusinessRelative>>();
            services.AddScoped<IRepository<PayIncentive>, Repository<PayIncentive>>();
            services.AddScoped<IRepository<Warehouse>, Repository<Warehouse>>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddCors();
            services.AddDbContext<OnlineContextDb>(options => options.UseSqlServer(Configuration.GetConnectionString("OnlineContext"), b => b.MigrationsAssembly("IMSERP")));
            services.AddDbContext<OnlineIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OnlineContextIdentity"), b => b.MigrationsAssembly("IMSERP")));
            services.AddIdentity<User, IdentityRole>(option => {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredUniqueChars = 0;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<OnlineIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {
                 x.SaveToken = false;
                 x.RequireHttpsMetadata = false;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ClockSkew = TimeSpan.Zero,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["IMSSetting:IMSSequrity"].ToString()))
                 };
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/api/swagger.json", "TestSweggarTwo v1")
            );
            app.UseStaticFiles();
            app.UseCors(options => options
                           .WithOrigins(Configuration["IMSSetting:IMSHost"].ToString())
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/{id?}");
            });
        }
    }
}
