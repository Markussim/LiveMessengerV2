using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Collections.Generic;

namespace LiveMessenger
{
    public class Startup
    {

        private List<Room> rooms = new List<Room>();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

          //  app.UseAuthorization();

            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.Use(async (context, next) =>
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        using (var webSocket = await context.WebSockets.AcceptWebSocketAsync())
                        {
                            string id = context.Request.Query["id"];
                            if (!string.IsNullOrEmpty(id) && checkRoom.byID(id))
                            {
                                int roomPosition = -1;
                                for (int i = 0; i < rooms.Count; i++)
                                {
                                    if (rooms[i].roomID == id)
                                    {
                                        roomPosition = i;
                                        break;
                                    }
                                }
                                if (roomPosition == -1)
                                {
                                    rooms.Add(new Room(id));
                                    roomPosition = rooms.Count - 1;
                                }
                                ClientConnection client = new ClientConnection(webSocket, context, rooms[roomPosition]);
                                rooms[roomPosition].Subscribe(client);
                                await client.Startup();
                            }
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    }


                });
        }

    }
}
