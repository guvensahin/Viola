using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Viola.DAL;
using System.Collections.Generic;

namespace Viola.Models
{
    public class TaskAssignedUser
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Task")]
        public int TaskId { get; set; }

        [Key]
        [Required]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("User")]
        public string UserId { get; set; }

        [DisplayName("Company")]
        public int CompanyId { get; set; }

        [DisplayName("Created user")]
        public string CreatedUserId { get; set; }

        [DisplayName("Created datetime")]
        public DateTime CreatedDatetime { get; set; }

        // child relations
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual Company Company { get; set; }


        // varsay�lan de�erler
        public void InitCreateValue()
        {
            CompanyId = Company.GetCurrentCompanyId();
            CreatedDatetime = DateTime.Now.ToUniversalTime();
            CreatedUserId = User.GetCurrentUserId();
        }


        public static void Create(int _taskId, string[] selection)
        {
            using (var db = new ViolaContext())
            {
                // mevcut ili�kiler silinir.
                foreach (var row in db.TaskAssignedUsers.Where(x => x.TaskId == _taskId))
                {
                    db.TaskAssignedUsers.Remove(row);
                }

                // yeni ili�kiler kaydedilir
                if (selection != null)
                {
                    foreach (var id in selection)
                    {
                        var row = new TaskAssignedUser
                        {
                            TaskId = _taskId,
                            UserId = id
                        };
                        row.InitCreateValue();

                        // e�er projeye ekibinde yer alan bir kullan�c� ise task ile ili�kilendirilir.
                        if (Viola.Models.User.GetUsersAssignedToProject(Task.Find(_taskId).ProjectId).Where(x => x.Id == row.UserId).Any())
                        {
                           db.TaskAssignedUsers.Add(row);
                        }
                    }
                }

                db.SaveChanges();
            }
        }

        public static List<string> UserIdSelection(int _projectId)
        {
            var ret = new List<string>();

            using (var db = new ViolaContext())
            {
                var rows = db.TaskAssignedUsers.Where(x => x.TaskId == _projectId);
                foreach (var row in rows)
                {
                    ret.Add(row.UserId);
                }
            }

            return ret;
        }



        public static bool Exist(int taskId, string userId)
        {
            var db = new ViolaContext();
            return db.TaskAssignedUsers.Where(x => x.TaskId == taskId && x.UserId == userId).Any();
        }

    }
}
