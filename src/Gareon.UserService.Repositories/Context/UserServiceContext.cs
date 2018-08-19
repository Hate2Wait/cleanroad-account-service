using System.Text;
using Gareon.UserService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Gareon.UserService.Repositories.Context
{
    public partial class UserServiceContext : DbContext
    {
        private readonly IOptions<DatabaseConnectionOptions> connectionOptions;

        public UserServiceContext(IOptions<DatabaseConnectionOptions> connectionOptions)
        {
            this.connectionOptions = connectionOptions;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.BuildConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlockedUser>(entity =>
            {
                entity.HasKey(e => new { e.UserJid, e.Type });

                entity.ToTable("_BlockedUser");

                entity.Property(e => e.UserJid).HasColumnName("UserJID");

                entity.Property(e => e.TimeBegin)
                    .HasColumnName("timeBegin")
                    .HasColumnType("datetime");

                entity.Property(e => e.TimeEnd)
                    .HasColumnName("timeEnd")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CasData>(entity =>
            {
                entity.HasKey(e => e.NSerial);

                entity.ToTable("_CasData");

                entity.Property(e => e.NSerial).HasColumnName("nSerial");

                entity.Property(e => e.BtUserChecked)
                    .HasColumnName("btUserChecked")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DProcessDate)
                    .HasColumnName("dProcessDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DReportDate)
                    .HasColumnName("dReportDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DwUserJid).HasColumnName("dwUserJID");

                entity.Property(e => e.NCategory).HasColumnName("nCategory");

                entity.Property(e => e.NStatus)
                    .HasColumnName("nStatus")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SzAnswer)
                    .HasColumnName("szAnswer")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.SzCharName)
                    .IsRequired()
                    .HasColumnName("szCharName")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SzChatLog)
                    .IsRequired()
                    .HasColumnName("szChatLog")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SzMailAddress)
                    .IsRequired()
                    .HasColumnName("szMailAddress")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SzMemo)
                    .HasColumnName("szMemo")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SzProcessedGm)
                    .HasColumnName("szProcessedGM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SzStatement)
                    .IsRequired()
                    .HasColumnName("szStatement")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SzTgtCharName)
                    .HasColumnName("szTgtCharName")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.WShardId).HasColumnName("wShardID");
            });

            modelBuilder.Entity<CasGmchatLog>(entity =>
            {
                entity.HasKey(e => e.NSerial);

                entity.ToTable("_CasGMChatLog");

                entity.Property(e => e.NSerial).HasColumnName("nSerial");

                entity.Property(e => e.DWritten)
                    .HasColumnName("dWritten")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NCasSerial).HasColumnName("nCasSerial");

                entity.Property(e => e.SzCharName)
                    .IsRequired()
                    .HasColumnName("szCharName")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SzGm)
                    .IsRequired()
                    .HasColumnName("szGM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SzGmchatLog)
                    .HasColumnName("szGMChatLog")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.WShardId).HasColumnName("wShardID");
            });

            modelBuilder.Entity<ModuleVersion>(entity =>
            {
                entity.HasKey(e => e.NId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("_ModuleVersion");

                entity.HasIndex(e => e.NModuleId)
                    .HasName("IX__ModuleVersion")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.NId).HasColumnName("nID");

                entity.Property(e => e.NContentId).HasColumnName("nContentID");

                entity.Property(e => e.NDivisionId).HasColumnName("nDivisionID");

                entity.Property(e => e.NModuleId).HasColumnName("nModuleID");

                entity.Property(e => e.NValid).HasColumnName("nValid");

                entity.Property(e => e.NVersion).HasColumnName("nVersion");

                entity.Property(e => e.SzDesc)
                    .IsRequired()
                    .HasColumnName("szDesc")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SzVersion)
                    .IsRequired()
                    .HasColumnName("szVersion")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModuleVersionFile>(entity =>
            {
                entity.HasKey(e => e.NId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("_ModuleVersionFile");

                entity.HasIndex(e => e.NModuleId)
                    .HasName("IX__ModuleVersionFile")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.NId).HasColumnName("nID");

                entity.Property(e => e.NContentId).HasColumnName("nContentID");

                entity.Property(e => e.NDivisionId).HasColumnName("nDivisionID");

                entity.Property(e => e.NFileSize).HasColumnName("nFileSize");

                entity.Property(e => e.NFileType).HasColumnName("nFileType");

                entity.Property(e => e.NFileTypeVersion).HasColumnName("nFileTypeVersion");

                entity.Property(e => e.NModuleId).HasColumnName("nModuleID");

                entity.Property(e => e.NToBePacked).HasColumnName("nToBePacked");

                entity.Property(e => e.NValid).HasColumnName("nValid");

                entity.Property(e => e.NVersion).HasColumnName("nVersion");

                entity.Property(e => e.SzFilename)
                    .IsRequired()
                    .HasColumnName("szFilename")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SzPath)
                    .IsRequired()
                    .HasColumnName("szPath")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TimeModified)
                    .HasColumnName("timeModified")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("_Notice");

                entity.HasIndex(e => e.ContentId)
                    .HasName("IX__Notice")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Article)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBlockedUser>(entity =>
            {
                entity.HasKey(e => e.UserJid);

                entity.ToTable("_OldBlockedUser");

                entity.HasIndex(e => e.UserJid)
                    .HasName("IX__BlockedUser");

                entity.Property(e => e.UserJid)
                    .HasColumnName("UserJID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TimeBegin)
                    .HasColumnName("timeBegin")
                    .HasColumnType("datetime");

                entity.Property(e => e.TimeEnd)
                    .HasColumnName("timeEnd")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Punishment>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("_Punishment");

                entity.HasIndex(e => e.UserJid)
                    .HasName("IX__Punishment")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.BlockEndTime).HasColumnType("datetime");

                entity.Property(e => e.BlockStartTime).HasColumnType("datetime");

                entity.Property(e => e.CharInfo)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CharName)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Executor)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Guide)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PosInfo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PunishTime).HasColumnType("datetime");

                entity.Property(e => e.RaiseTime).HasColumnType("datetime");

                entity.Property(e => e.UserJid).HasColumnName("UserJID");
            });

            modelBuilder.Entity<QuaySoEpoint>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CharId).HasColumnName("CharID");

                entity.Property(e => e.CharName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Regdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SourcePoint)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SpAfter).HasColumnName("SP_After");

                entity.Property(e => e.SpBefore).HasColumnName("SP_Before");

                entity.Property(e => e.SpOwn).HasColumnName("SP_Own");

                entity.Property(e => e.UserCash)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefCountryNameAndCode>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("_RefCountryNameAndCode");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SzCountryName)
                    .IsRequired()
                    .HasColumnName("szCountryName")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shard>(entity =>
            {
                entity.HasKey(e => e.NId);

                entity.ToTable("_Shard");

                entity.Property(e => e.NId).HasColumnName("nID");

                entity.Property(e => e.NContentId).HasColumnName("nContentID");

                entity.Property(e => e.NCurrentUserRatio)
                    .HasColumnName("nCurrentUserRatio")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NFarmId).HasColumnName("nFarmID");

                entity.Property(e => e.NMaxUser)
                    .HasColumnName("nMaxUser")
                    .HasDefaultValueSql("(1000)");

                entity.Property(e => e.NStartupServerId)
                    .HasColumnName("nStartupServerID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NStatus)
                    .HasColumnName("nStatus")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SzDbconfig)
                    .IsRequired()
                    .HasColumnName("szDBConfig")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SzDesc)
                    .IsRequired()
                    .HasColumnName("szDesc")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SzName)
                    .IsRequired()
                    .HasColumnName("szName")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShardCurrentUser>(entity =>
            {
                entity.HasKey(e => e.NId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("_ShardCurrentUser");

                entity.HasIndex(e => e.NShardId)
                    .HasName("IX__ShardCurrentUser")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.NId).HasColumnName("nID");

                entity.Property(e => e.DLogDate)
                    .HasColumnName("dLogDate")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NShardId).HasColumnName("nShardID");

                entity.Property(e => e.NUserCount).HasColumnName("nUserCount");
            });

            modelBuilder.Entity<SiegeFortressStatus>(entity =>
            {
                entity.HasKey(e => new { e.ShardId, e.FortressName });

                entity.ToTable("__SiegeFortressStatus__");

                entity.Property(e => e.ShardId).HasColumnName("ShardID");

                entity.Property(e => e.FortressName)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAllianceGuildName1)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAllianceGuildName2)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAllianceGuildName3)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAllianceGuildName4)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAllianceGuildName5)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAllianceGuildName6)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAllianceGuildName7)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAllianceGuildName8)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerGuildMaster)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerGuildName)
                    .HasMaxLength(129)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerUpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SkCharRenameLog>(entity =>
            {
                entity.ToTable("SK_CharRenameLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Jid).HasColumnName("JID");

                entity.Property(e => e.NewChar)
                    .HasColumnName("new_char")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OldChar)
                    .HasColumnName("old_char")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Server)
                    .HasColumnName("server")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Struserid)
                    .HasColumnName("struserid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timechange)
                    .HasColumnName("timechange")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SkDownLevelLog>(entity =>
            {
                entity.ToTable("SK_DownLevelLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Charname)
                    .HasColumnName("charname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Jid).HasColumnName("JID");

                entity.Property(e => e.Newlevel)
                    .HasColumnName("newlevel")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Package)
                    .HasColumnName("package")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Server)
                    .HasColumnName("server")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Struserid)
                    .HasColumnName("struserid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Timedown)
                    .HasColumnName("timedown")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SkResetSkillLog>(entity =>
            {
                entity.ToTable("SK_ResetSkillLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Charname)
                    .HasColumnName("charname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Jid).HasColumnName("JID");

                entity.Property(e => e.NewSkill)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Server)
                    .HasColumnName("server")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SilkDown)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SkillDown)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Struserid)
                    .HasColumnName("struserid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeReset).HasColumnType("datetime");
            });

            modelBuilder.Entity<SkShl>(entity =>
            {
                entity.HasKey(e => e.Idx)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("SK_SHL");

                entity.HasIndex(e => e.Jid)
                    .HasName("IX_SK_SHL")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Idx).HasColumnName("idx");

                entity.Property(e => e.Cgs).HasColumnName("CGS");

                entity.Property(e => e.Cos).HasColumnName("COS");

                entity.Property(e => e.EventTime)
                    .HasColumnName("event_time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Hgs).HasColumnName("HGS");

                entity.Property(e => e.Hos).HasColumnName("HOS");

                entity.Property(e => e.Jid).HasColumnName("JID");
            });

            modelBuilder.Entity<SrCharNames>(entity =>
            {
                entity.HasKey(e => new { e.UserJid, e.ShardId });

                entity.ToTable("SR_CharNames");

                entity.Property(e => e.UserJid).HasColumnName("UserJID");

                entity.Property(e => e.ShardId).HasColumnName("ShardID");

                entity.Property(e => e.CharId1)
                    .IsRequired()
                    .HasColumnName("CharID_1")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.CharId2)
                    .HasColumnName("CharID_2")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.CharId3)
                    .HasColumnName("CharID_3")
                    .HasMaxLength(17)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbNet2e>(entity =>
            {
                entity.HasKey(e => e.Jid);

                entity.ToTable("TB_Net2e");

                entity.Property(e => e.Jid)
                    .HasColumnName("JID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(100);

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasMaxLength(50);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CertificateNum)
                    .HasColumnName("certificate_num")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(70);

                entity.Property(e => e.CidType).HasColumnName("cidType");

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Freetime).HasColumnName("freetime");

                entity.Property(e => e.Games)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gmrank).HasColumnName("GMrank");

                entity.Property(e => e.Inviter)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastModification).HasColumnType("datetime");

                entity.Property(e => e.Mdk)
                    .HasColumnName("MDK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Province).HasMaxLength(50);

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasMaxLength(70);

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegIp)
                    .HasColumnName("reg_ip")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Regtime)
                    .HasColumnName("regtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SecAct)
                    .HasColumnName("Sec_act")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecContent).HasColumnName("sec_content");

                entity.Property(e => e.SecPrimary).HasColumnName("sec_primary");

                entity.Property(e => e.SecondPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.StrLevel)
                    .HasColumnName("strLevel")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StrUserId)
                    .IsRequired()
                    .HasColumnName("StrUserID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TimeLog)
                    .HasColumnName("Time_log")
                    .HasColumnType("datetime");

                entity.Property(e => e.WhereKnow)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WherePlay).HasMaxLength(50);
            });

            modelBuilder.Entity<TbPartnerInfo>(entity =>
            {
                entity.HasKey(e => e.PartnerId);

                entity.ToTable("tb_partnerInfo");

                entity.Property(e => e.PartnerId)
                    .HasColumnName("partnerID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Balance)
                    .HasColumnName("balance")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PartnerName)
                    .HasColumnName("partnerName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PartnerPass)
                    .HasColumnName("partnerPass")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Udate)
                    .HasColumnName("udate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPaygateTrans>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tb_paygate_trans");

                entity.Property(e => e.TransId).HasColumnName("trans_ID");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AfterMoney)
                    .HasColumnName("afterMoney")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BankId)
                    .HasColumnName("bank_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BeforeMoney)
                    .HasColumnName("beforeMoney")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.MoneyValue)
                    .HasColumnName("moneyValue")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PgTransId).HasColumnName("PG_TransID");

                entity.Property(e => e.TransDate)
                    .HasColumnName("trans_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransType)
                    .HasColumnName("trans_type")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.Jid);

                entity.ToTable("TB_User");

                entity.Property(e => e.Jid).HasColumnName("JID");

                entity.Property(e => e.AccPlayTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(100);

                entity.Property(e => e.CertificateNum)
                    .HasColumnName("certificate_num")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Freetime).HasColumnName("freetime");

                entity.Property(e => e.Gmrank).HasColumnName("GMrank");

                entity.Property(e => e.LatestUpdateTimeToPlayTime)
                    .HasColumnName("LatestUpdateTime_ToPlayTime")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegIp)
                    .HasColumnName("reg_ip")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Regtime)
                    .HasColumnName("regtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SecContent)
                    .HasColumnName("sec_content")
                    .HasDefaultValueSql("(3)");

                entity.Property(e => e.SecPrimary)
                    .HasColumnName("sec_primary")
                    .HasDefaultValueSql("(3)");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.StrUserId)
                    .IsRequired()
                    .HasColumnName("StrUserID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TimeLog)
                    .HasColumnName("Time_log")
                    .HasColumnType("datetime");

                entity.Property(e => e.SecretCode)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.SecretCodeSalt)
                    .IsRequired();
            });

            modelBuilder.Entity<TrijobRanking>(entity =>
            {
                entity.HasKey(e => new { e.ShardId, e.TrijobType, e.RankType, e.Rank });

                entity.ToTable("__TrijobRanking__");

                entity.HasIndex(e => e.NickName)
                    .HasName("IX___TrijobRanking__");

                entity.Property(e => e.ShardId).HasColumnName("ShardID");

                entity.Property(e => e.Country).HasDefaultValueSql("(0)");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrijobRankingStatus>(entity =>
            {
                entity.HasKey(e => e.ShardId);

                entity.ToTable("__TrijobRankingStatus__");

                entity.Property(e => e.ShardId)
                    .HasColumnName("ShardID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UpdateTime).HasColumnType("smalldatetime");
            });
        }

        private string BuildConnectionString()
        {
            var connectionString =  new StringBuilder($"Server={this.connectionOptions.Value.Server};")
                .Append($"Database={this.connectionOptions.Value.Database};")
                .Append($"User Id={this.connectionOptions.Value.UserId};")
                .Append($"Password={this.connectionOptions.Value.Password};")
                .ToString();

            return connectionString;
        }
    }
}
