using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PropertyManageSystem.Models;

public partial class WuyeProjectContext : DbContext
{
    public WuyeProjectContext()
    {
    }

    public WuyeProjectContext(DbContextOptions<WuyeProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<WAdmin> WAdmins { get; set; }

    public virtual DbSet<WAnnouncement> WAnnouncements { get; set; }

    public virtual DbSet<WBuilding> WBuildings { get; set; }

    public virtual DbSet<WComplaint> WComplaints { get; set; }

    public virtual DbSet<WDevice> WDevices { get; set; }

    public virtual DbSet<WHouse> WHouses { get; set; }

    public virtual DbSet<WInstallation> WInstallations { get; set; }

    public virtual DbSet<WPacking> WPackings { get; set; }

    public virtual DbSet<WPropertyUser> WPropertyUsers { get; set; }

    public virtual DbSet<WRepair> WRepairs { get; set; }

    public virtual DbSet<WRoom> WRooms { get; set; }

    public virtual DbSet<WRoomInfo> WRoomInfos { get; set; }

    public virtual DbSet<WSystemParam> WSystemParams { get; set; }

    public virtual DbSet<WUser> WUsers { get; set; }

    public virtual DbSet<WUserPaymoney> WUserPaymoneys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WuyeProject;Integrated Security=True;TrustServerCertificate=true;Initial Catalog=WuyeProject");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WAdmin>(entity =>
        {
            entity.ToTable("w_admin");

            entity.HasIndex(e => e.UserName, "IX_w_admin").IsUnique();

            entity.Property(e => e.CreateTime).HasColumnType("date");
            entity.Property(e => e.NickName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Power).HasDefaultValueSql("((0))");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WAnnouncement>(entity =>
        {
            entity.ToTable("w_announcement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contents)
                .HasColumnType("text")
                .HasColumnName("contents");
            entity.Property(e => e.Createtime)
                .HasColumnType("date")
                .HasColumnName("createtime");
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nickname");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Uid).HasColumnName("uid");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.WAnnouncements)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK_w_announcement_w_admin");
        });

        modelBuilder.Entity<WBuilding>(entity =>
        {
            entity.ToTable("w_building");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("area");
            entity.Property(e => e.Createtime)
                .HasColumnType("date")
                .HasColumnName("createtime");
            entity.Property(e => e.Floors).HasColumnName("floors");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("height");
            entity.Property(e => e.Remark)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("remark");
            entity.Property(e => e.RoomName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room_name");
            entity.Property(e => e.SpId).HasColumnName("sp_id");

            entity.HasOne(d => d.Sp).WithMany(p => p.WBuildings)
                .HasForeignKey(d => d.SpId)
                .HasConstraintName("FK_w_building_w_building");
        });

        modelBuilder.Entity<WComplaint>(entity =>
        {
            entity.ToTable("w_complaint");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Createtime)
                .HasColumnType("date")
                .HasColumnName("createtime");
            entity.Property(e => e.Describe)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("describe");
            entity.Property(e => e.HouseId).HasColumnName("house_id");
            entity.Property(e => e.IsUse).HasColumnName("is_use");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PassDetail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pass_detail");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Result)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("result");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Uid).HasColumnName("uid");

            entity.HasOne(d => d.House).WithMany(p => p.WComplaints)
                .HasForeignKey(d => d.HouseId)
                .HasConstraintName("FK_w_complaint_w_house");
        });

        modelBuilder.Entity<WDevice>(entity =>
        {
            entity.ToTable("w_device");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createtime)
                .HasColumnType("date")
                .HasColumnName("createtime");
            entity.Property(e => e.DeviceDesc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("device_desc");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("device_name");
        });

        modelBuilder.Entity<WHouse>(entity =>
        {
            entity.ToTable("w_house");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("area");
            entity.Property(e => e.BId).HasColumnName("b_id");
            entity.Property(e => e.BzId).HasColumnName("bz_id");
            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.DId).HasColumnName("d_id");
            entity.Property(e => e.DRoom).HasColumnName("d_room");
            entity.Property(e => e.GId).HasColumnName("g_id");
            entity.Property(e => e.IsUse).HasColumnName("is_use");
            entity.Property(e => e.RId).HasColumnName("r_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UseArea)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("use_area");

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.WHouses)
                .HasForeignKey(d => d.BId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_w_house_w_building");

            entity.HasOne(d => d.Bz).WithMany(p => p.WHouseBzs)
                .HasForeignKey(d => d.BzId)
                .HasConstraintName("FK_w_house_w_system_params5");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.WHouseCIdNavigations)
                .HasForeignKey(d => d.CId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_w_house_w_system_params2");

            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.WHouseDIdNavigations)
                .HasForeignKey(d => d.DId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_w_house_w_system_params");

            entity.HasOne(d => d.DRoomNavigation).WithMany(p => p.WHouseDRoomNavigations)
                .HasForeignKey(d => d.DRoom)
                .HasConstraintName("FK_w_house_w_system_params1");

            entity.HasOne(d => d.GIdNavigation).WithMany(p => p.WHouseGIdNavigations)
                .HasForeignKey(d => d.GId)
                .HasConstraintName("FK_w_house_w_system_params4");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.WHouseRIdNavigations)
                .HasForeignKey(d => d.RId)
                .HasConstraintName("FK_w_house_w_system_params3");
        });

        modelBuilder.Entity<WInstallation>(entity =>
        {
            entity.ToTable("w_installation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contents)
                .HasColumnType("text")
                .HasColumnName("contents");
            entity.Property(e => e.MainName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("main_name");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.SpId).HasColumnName("sp_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Sp).WithMany(p => p.WInstallations)
                .HasForeignKey(d => d.SpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_w_installation_w_installation");
        });

        modelBuilder.Entity<WPacking>(entity =>
        {
            entity.ToTable("w_packing");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PackingArea)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("packing_area");
            entity.Property(e => e.PackingLot)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("packing_lot");
            entity.Property(e => e.PackingLotId).HasColumnName("packing_lotID");
            entity.Property(e => e.PackingName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("packing_name");
            entity.Property(e => e.PackingState).HasColumnName("packing_state");
            entity.Property(e => e.PackingType).HasColumnName("packing_type");
            entity.Property(e => e.PackingUid).HasColumnName("packing_uid");

            entity.HasOne(d => d.Packin).WithMany(p => p.WPackings)
                .HasForeignKey(d => d.PackingUid)
                .HasConstraintName("FK_w_packing_w_packing");
        });

        modelBuilder.Entity<WPropertyUser>(entity =>
        {
            entity.ToTable("w_property_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_number");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Pic)
                .HasColumnType("text")
                .HasColumnName("pic");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.WorkInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("work_info");
            entity.Property(e => e.WorkName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("work_name");
            entity.Property(e => e.WyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("wy_number");
        });

        modelBuilder.Entity<WRepair>(entity =>
        {
            entity.ToTable("w_repair");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createtime)
                .HasColumnType("date")
                .HasColumnName("createtime");
            entity.Property(e => e.DanyuanId).HasColumnName("danyuan_id");
            entity.Property(e => e.Describe)
                .HasColumnType("text")
                .HasColumnName("describe");
            entity.Property(e => e.FinalyRepairUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("finaly_repair_user");
            entity.Property(e => e.HouseId).HasColumnName("house_id");
            entity.Property(e => e.LouyuId).HasColumnName("louyu_id");
            entity.Property(e => e.MainRepairUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("main_repair_user");
            entity.Property(e => e.PassDetail)
                .HasColumnType("text")
                .HasColumnName("pass_detail");
            entity.Property(e => e.RepairInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("repair_info");
            entity.Property(e => e.RepairNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("repair_number");
            entity.Property(e => e.RepairPass).HasColumnName("repair_pass");
            entity.Property(e => e.RepairPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("repair_phone");
            entity.Property(e => e.RepairWorkInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("repair_work_info");
            entity.Property(e => e.RepeatInfo)
                .HasColumnType("text")
                .HasColumnName("repeat_info");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.StateType).HasColumnName("state_type");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.UnitName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unit_name");

            entity.HasOne(d => d.Danyuan).WithMany(p => p.WRepairs)
                .HasForeignKey(d => d.DanyuanId)
                .HasConstraintName("FK_w_repair_w_system_params");

            entity.HasOne(d => d.House).WithMany(p => p.WRepairs)
                .HasForeignKey(d => d.HouseId)
                .HasConstraintName("FK_w_repair_w_house");

            entity.HasOne(d => d.Louyu).WithMany(p => p.WRepairs)
                .HasForeignKey(d => d.LouyuId)
                .HasConstraintName("FK_w_repair_w_building");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.WRepairs)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK_w_repair_w_user");
        });

        modelBuilder.Entity<WRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_w_room_1");

            entity.ToTable("w_room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("actual_area");
            entity.Property(e => e.ConstructionArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("construction_area");
            entity.Property(e => e.Floor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("floor");
            entity.Property(e => e.HomeState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("home_state");
            entity.Property(e => e.Owner)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("owner");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoomId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<WRoomInfo>(entity =>
        {
            entity.ToTable("w_room_info");

            entity.Property(e => e.CommunityAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CommunityName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CommunityRemark)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ConstructDate).HasColumnType("date");
            entity.Property(e => e.ManagerName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ManagerPhone)
                .HasMaxLength(16)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WSystemParam>(entity =>
        {
            entity.ToTable("w_system_params");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<WUser>(entity =>
        {
            entity.ToTable("w_user");

            entity.HasIndex(e => e.Username1, "IX_w_user").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuildingId).HasColumnName("building_id");
            entity.Property(e => e.Createtime)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createtime");
            entity.Property(e => e.DanyuanId).HasColumnName("danyuan_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.HouseId).HasColumnName("house_id");
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("house_number");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_number");
            entity.Property(e => e.LinkAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("link_address");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Remark)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("remark");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.Username1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.WorkAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("work_address");

            entity.HasOne(d => d.Building).WithMany(p => p.WUsers)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK_w_user_w_building");

            entity.HasOne(d => d.Danyuan).WithMany(p => p.WUsers)
                .HasForeignKey(d => d.DanyuanId)
                .HasConstraintName("FK_w_user_w_system_params");

            entity.HasOne(d => d.House).WithMany(p => p.WUsers)
                .HasForeignKey(d => d.HouseId)
                .HasConstraintName("FK_w_user_w_house");
        });

        modelBuilder.Entity<WUserPaymoney>(entity =>
        {
            entity.ToTable("w_user_paymoney");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ById).HasColumnName("by_id");
            entity.Property(e => e.HouseId).HasColumnName("house_id");
            entity.Property(e => e.NoPay)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("no_pay");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RealyPay)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("realy_pay");
            entity.Property(e => e.ShouldPay)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("should_pay");
            entity.Property(e => e.StartPayTime)
                .HasColumnType("datetime")
                .HasColumnName("start_pay_time");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.By).WithMany(p => p.WUserPaymoneys)
                .HasForeignKey(d => d.ById)
                .HasConstraintName("FK_w_user_paymoney_w_admin");

            entity.HasOne(d => d.House).WithMany(p => p.WUserPaymoneys)
                .HasForeignKey(d => d.HouseId)
                .HasConstraintName("FK_w_user_paymoney_w_house");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
