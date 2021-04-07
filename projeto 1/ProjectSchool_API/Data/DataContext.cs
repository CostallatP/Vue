
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Aluno> Alunos{get;set;}
        public DbSet<Professor> Professores{get;set;}

   
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
            .HasData(
                new List<Professor>(){
                    new Professor(){
                        Id= 1,
                        Nome = "Adriana"
                    },
                       new Professor(){
                        Id= 2,
                        Nome = "Bernado"
                    },
                       new Professor(){
                        Id= 3,
                        Nome = "Carlos"
                    }
                }
            );

                   builder.Entity<Aluno>()
            .HasData(
                new List<Aluno>(){
                    new Aluno(){
                        Id= 1,
                        Nome = "Miguel",
                        Sobrenome= "Costallat",
                        DataNasc = "28/04/2000",
                        ProfessorId = 1
                    },
                       new Aluno(){
                        Id= 2,
                        Nome = "João",
                        Sobrenome= "Henrique",
                        DataNasc = "01/01/2001",
                        ProfessorId = 2
                    },
                       new Aluno(){
                        Id= 3,
                        Nome = "Alex",
                        Sobrenome= "Alexania",
                        DataNasc = "02/02/2002",
                        ProfessorId = 3
                    }
                }
            );
        }
        }
    }
