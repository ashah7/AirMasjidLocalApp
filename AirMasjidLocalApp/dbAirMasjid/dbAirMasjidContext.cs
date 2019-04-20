using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AirMasjidLocalApp.dbAirMasjid
{
    public partial class dbAirMasjidContext : DbContext
    {
        public dbAirMasjidContext()
        {
        }

        public dbAirMasjidContext(DbContextOptions<dbAirMasjidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sysdiagrams> Sysdiagrams { get; set; }
        public virtual DbSet<TblCameraLookup> TblCameraLookup { get; set; }
        public virtual DbSet<TblCameras> TblCameras { get; set; }
        public virtual DbSet<TblEstablishment> TblEstablishment { get; set; }
        public virtual DbSet<TblEventlookup> TblEventlookup { get; set; }
        public virtual DbSet<TblEvents> TblEvents { get; set; }
        public virtual DbSet<TblPreferences> TblPreferences { get; set; }
        public virtual DbSet<TblRegistrations> TblRegistrations { get; set; }
        public virtual DbSet<TblSerialRegistration> TblSerialRegistration { get; set; }
        public virtual DbSet<TblStreamLookup> TblStreamLookup { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }
        public virtual DbSet<Tblnameaddress> Tblnameaddress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySql("server=amp-hxp100.airmyprayer.co.uk;port=2323;user=RadioUser;password=RadioUser1234*;database=dbAirMasjid");
//            }

            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.

                // optionsBuilder.UseMySql("server=amp-hxp100;port=3306;user=RadioUser;password=RadioUser1234*;database=dbAirMasjid");

                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString);


            }







        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.DiagramId)
                    .HasName("PRIMARY");

                entity.ToTable("sysdiagrams");

                entity.HasIndex(e => new { e.PrincipalId, e.Name })
                    .HasName("UK_principal_name")
                    .IsUnique();

                entity.Property(e => e.DiagramId)
                    .HasColumnName("diagram_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(160)");

                entity.Property(e => e.PrincipalId)
                    .HasColumnName("principal_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblCameraLookup>(entity =>
            {
                entity.HasKey(e => e.CameraelementId)
                    .HasName("PRIMARY");

                entity.ToTable("tblCameraLookup");

                entity.HasIndex(e => e.CamerasId)
                    .HasName("FK_tblCameraLookup_tblCameras");

                entity.Property(e => e.CameraelementId)
                    .HasColumnName("CameraelementID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cameradelay)
                    .HasColumnName("cameradelay")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CamerasId)
                    .HasColumnName("CamerasID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cdn)
                    .HasColumnName("CDN")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Description).HasColumnType("varchar(200)");

                entity.Property(e => e.RstpCamera)
                    .HasColumnName("rstpCamera")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.RstpCameraTarget)
                    .HasColumnName("rstpCameraTarget")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Script)
                    .HasColumnName("script")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Cameras)
                    .WithMany(p => p.TblCameraLookup)
                    .HasForeignKey(d => d.CamerasId)
                    .HasConstraintName("tblCameraLookup_ibfk_1");
            });

            modelBuilder.Entity<TblCameras>(entity =>
            {
                entity.HasKey(e => e.CamerasId)
                    .HasName("PRIMARY");

                entity.ToTable("tblCameras");

                entity.Property(e => e.CamerasId)
                    .HasColumnName("CamerasID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EstablishId)
                    .HasColumnName("EstablishID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblEstablishment>(entity =>
            {
                entity.HasKey(e => e.EstablishId)
                    .HasName("PRIMARY");

                entity.ToTable("tblEstablishment");

                entity.HasIndex(e => e.CamerasId)
                    .HasName("FK_tblEstablishment_tblCameras");

                entity.HasIndex(e => e.EventsId)
                    .HasName("FK_tblEstablishment_tblEvents");

                entity.HasIndex(e => e.StreamId)
                    .HasName("FK_tblEstablishment_tblStreamLookup1");

                entity.Property(e => e.EstablishId)
                    .HasColumnName("EstablishID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CamerasId)
                    .HasColumnName("CamerasID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description).HasColumnType("varchar(200)");

                entity.Property(e => e.EventsId)
                    .HasColumnName("EventsID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StreamId)
                    .HasColumnName("StreamID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TweetId)
                    .HasColumnName("TweetID")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Cameras)
                    .WithMany(p => p.TblEstablishment)
                    .HasForeignKey(d => d.CamerasId)
                    .HasConstraintName("tblEstablishment_ibfk_1");

                entity.HasOne(d => d.Events)
                    .WithMany(p => p.TblEstablishment)
                    .HasForeignKey(d => d.EventsId)
                    .HasConstraintName("tblEstablishment_ibfk_2");

                entity.HasOne(d => d.Stream)
                    .WithMany(p => p.TblEstablishment)
                    .HasForeignKey(d => d.StreamId)
                    .HasConstraintName("tblEstablishment_ibfk_3");
            });

            modelBuilder.Entity<TblEventlookup>(entity =>
            {
                entity.HasKey(e => e.EventselementId)
                    .HasName("PRIMARY");

                entity.ToTable("tblEventlookup");

                entity.HasIndex(e => e.EventsId)
                    .HasName("FK_tblEventlookup_tblEvents1");

                entity.Property(e => e.EventselementId)
                    .HasColumnName("EventselementID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AutoScreen).HasColumnType("int(11)");

                entity.Property(e => e.Broadcastday)
                    .HasColumnName("broadcastday")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.EventsId)
                    .HasColumnName("EventsID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Eventurl)
                    .HasColumnName("eventurl")
                    .HasColumnType("varchar(500)");

                entity.HasOne(d => d.Events)
                    .WithMany(p => p.TblEventlookup)
                    .HasForeignKey(d => d.EventsId)
                    .HasConstraintName("tblEventlookup_ibfk_1");
            });

            modelBuilder.Entity<TblEvents>(entity =>
            {
                entity.HasKey(e => e.EventsId)
                    .HasName("PRIMARY");

                entity.ToTable("tblEvents");

                entity.Property(e => e.EventsId)
                    .HasColumnName("EventsID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.EstablishId)
                    .HasColumnName("EstablishID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Eventdesc)
                    .HasColumnName("eventdesc")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasColumnType("varchar(5)");
            });

            modelBuilder.Entity<TblPreferences>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("PRIMARY");

                entity.ToTable("tblPreferences");

                entity.HasIndex(e => e.EstablishId)
                    .HasName("FK_tblPreferences_tblEstablishment1");

                entity.HasIndex(e => e.Serial)
                    .HasName("FK_tblPreferences_tblSerialRegistration");

                entity.Property(e => e.Serial).HasColumnType("varchar(30)");

                entity.Property(e => e.AutoScreen).HasColumnType("varchar(1)");

                entity.Property(e => e.EstablishId)
                    .HasColumnName("EstablishID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Events).HasColumnType("int(11)");

                entity.Property(e => e.Patch)
                    .HasColumnName("patch")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.TahajjudAzan).HasColumnType("varchar(1)");

                entity.Property(e => e.ViewMode).HasColumnType("int(1)");

                entity.HasOne(d => d.Establish)
                    .WithMany(p => p.TblPreferences)
                    .HasForeignKey(d => d.EstablishId)
                    .HasConstraintName("tblPreferences_ibfk_1");

                entity.HasOne(d => d.SerialNavigation)
                    .WithOne(p => p.TblPreferences)
                    .HasForeignKey<TblPreferences>(d => d.Serial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblPreferences_ibfk_2");
            });

            modelBuilder.Entity<TblRegistrations>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("PRIMARY");

                entity.ToTable("tblRegistrations");

                entity.HasIndex(e => e.Serial)
                    .HasName("FK_tblRegistrations_tblSerialRegistration");

                entity.Property(e => e.Serial).HasColumnType("varchar(30)");

                entity.Property(e => e.Cloudserver)
                    .HasColumnName("cloudserver")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ExternalIp)
                    .HasColumnName("External IP")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.LocalIp)
                    .IsRequired()
                    .HasColumnName("Local IP")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Logintime).HasColumnType("datetime");

                entity.Property(e => e.PublicIp)
                    .HasColumnName("Public IP")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Virtualhub)
                    .HasColumnName("virtualhub")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Vpnip)
                    .HasColumnName("vpnip")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Vpnserver)
                    .HasColumnName("vpnserver")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.WifiQuality).HasColumnType("varchar(60)");

                entity.HasOne(d => d.SerialNavigation)
                    .WithOne(p => p.TblRegistrations)
                    .HasForeignKey<TblRegistrations>(d => d.Serial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblRegistrations_ibfk_1");
            });

            modelBuilder.Entity<TblSerialRegistration>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("PRIMARY");

                entity.ToTable("tblSerialRegistration");

                entity.HasIndex(e => e.Ownerid)
                    .HasName("fk_tblSerialRegistration_tblnameaddress1_idx");

                entity.Property(e => e.Serial).HasColumnType("varchar(30)");

                entity.Property(e => e.Hostname).HasColumnType("varchar(30)");

                entity.Property(e => e.Owner).HasColumnType("varchar(50)");

                entity.Property(e => e.Ownerid)
                    .HasColumnName("ownerid")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.TblSerialRegistration)
                    .HasForeignKey(d => d.Ownerid)
                    .HasConstraintName("tblSerialRegistration_ibfk_1");
            });

            modelBuilder.Entity<TblStreamLookup>(entity =>
            {
                entity.HasKey(e => e.StreamId)
                    .HasName("PRIMARY");

                entity.ToTable("tblStreamLookup");

                entity.Property(e => e.StreamId)
                    .HasColumnName("StreamID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description).HasColumnType("varchar(50)");

                entity.Property(e => e.Micstatus)
                    .HasColumnName("micstatus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StreamUrl)
                    .IsRequired()
                    .HasColumnName("Stream url")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Transmitter)
                    .HasColumnName("transmitter")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Transmitterport)
                    .HasColumnName("transmitterport")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("tblUsers");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Tblnameaddress>(entity =>
            {
                entity.HasKey(e => e.Ownerid)
                    .HasName("PRIMARY");

                entity.ToTable("tblnameaddress");

                entity.Property(e => e.Ownerid)
                    .HasColumnName("ownerid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasColumnName("town")
                    .HasColumnType("varchar(45)");
            });
        }
    }
}
