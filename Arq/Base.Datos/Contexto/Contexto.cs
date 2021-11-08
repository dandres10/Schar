namespace Base.Datos.Contexto
{
    using System.Data.Entity;

    public partial class Contexto : DbContext
    {
        public Contexto(): base("name=Contexto")
        {
        }

      

        public virtual DbSet<USUARIOS> USUARIOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.Apellido)
                .IsUnicode(false);
        }
    }
}