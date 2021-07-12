using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITFIS;

namespace View
{
    public class DatabaseControl : INotifyPropertyChanged
    {
        public User ActiveUser { get; set; }

        private ITFISDBEntities db;
        public List<Role> Roles = new List<Role>();
        public ObservableCollection<User> Users = new ObservableCollection<User>();
        public ObservableCollection<Course> Courses = new ObservableCollection<Course>();
        public ObservableCollection<Registration> Registrations = new ObservableCollection<Registration>();
        public ObservableCollection<Classification> Classifications = new ObservableCollection<Classification>();
        public event PropertyChangedEventHandler PropertyChanged;
        public DatabaseControl()
        { 
            db = new ITFISDBEntities();
            db.Users.ToList().ForEach(u => Users.Add(u));
            db.Roles.ToList().ForEach(r => Roles.Add(r));
            db.Courses.ToList().ForEach(c => Courses.Add(c));
            db.Registrations.ToList().ForEach(r => Registrations.Add(r));
            db.Classifications.ToList().ForEach(cl => Classifications.Add(cl));
            Sort();
        }
        protected void Change(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public void SetActiveUser(int ID)
        {
            ActiveUser = db.Users.First(u => u.Id == ID);
        }
        public bool CheckPassword(string password)
        {
            if (ActiveUser.Password.Trim() == password)
                return true;
            else return false;
        }
        private void Sort()
        {
            Users = new ObservableCollection<User>(Users.OrderBy(u => u.Surname));
            Courses = new ObservableCollection<Course>(Courses.OrderBy(c => c.Title));            
            Change(nameof(Users));
            Change(nameof(Courses));
        }
        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            Users.Add(user);
            Sort();
        }
        public void EditUser(User user)
        {
            db.Users.First(u => u.Id == user.Id).Name = user.Name;
            db.Users.First(u => u.Id == user.Id).Surname = user.Surname;
            db.Users.First(u => u.Id == user.Id).Password = user.Password;
            db.Users.First(u => u.Id == user.Id).RoleId = user.RoleId;
            db.SaveChanges();
            Sort();
        }
        public void DeleteUser(User user)
        {
            db.Users.Remove(db.Users.First(u => u.Id == user.Id));
            db.SaveChanges();
            Users.Remove(user);
            Sort();
        }

        public void AddCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            Courses.Add(course);
            Sort();
        }
        public void EditCourse(Course course)
        {
            db.Courses.First(c => c.Id == course.Id).Title = course.Title;
            db.Courses.First(c => c.Id == course.Id).LectorId = course.LectorId;
            db.Courses.First(c => c.Id == course.Id).Capacity = course.Capacity;
            db.Courses.First(c => c.Id == course.Id).Description = course.Description;
            db.SaveChanges();
            Sort();
        }
        public void DeleteCourse(Course course)
        {
            db.Courses.Remove(db.Courses.First(c => c.Id == course.Id));
            db.SaveChanges();
            Courses.Remove(course);
            Sort();
        }
        public ObservableCollection<User> Lectors()
        {
            ObservableCollection<User> lectors = new ObservableCollection<User>();
            foreach (User u in Users)
            {
                if (u.RoleId == 2)
                {
                    lectors.Add(u);
                }
            }
            return lectors;
        }
        /// <summary>
        /// Vrací kolekci se studenty
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<User> Students()
        {
            ObservableCollection<User> students = new ObservableCollection<User>();
            foreach (User u in Users)
            {
                if (u.RoleId == 3)
                {
                    students.Add(u);
                }
            }
            return students;
        }
        public User FindUser(int id)
        {
            User user = new User();
            foreach (User u in Users)
            {
                if (u.Id == id)
                    user = u;
            }
            return user;
        }
        /// <summary>
        /// Vrací kolekci studentů v daném kurzu
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public ObservableCollection<User> StudentsByCourse(int courseID)
        {
            ObservableCollection<User> studentsByCourse = new ObservableCollection<User>();
            foreach (Registration r in Registrations)
            {
                if (r.CourseId == courseID)
                {
                    studentsByCourse.Add(FindUser((int)r.UserId));
                }
            }
            return studentsByCourse;
        }
        /// <summary>
        /// Vytvoří registraci studenta a vloží ji do databáze
        /// Metoda nepříjímá již hotovou registraci, jelikož potřebuje přístup k maximální kapacitě kurzu a šetří tak další vyhledávání kurzu
        /// </summary>
        /// <param name="course"></param>
        /// <param name="user"></param>
        public void AddStudentToCourse(Course course, User user)
        {
            Registration registration = new Registration();
            registration.CourseId = course.Id;
            registration.UserId = user.Id;
            bool exist = false;
            int i = 0;
            foreach (Registration r in Registrations)
            {
                if (r == registration)
                    exist = true;
                if (r.CourseId == course.Id)
                    i++;
            }
            if (i >= course.Capacity)
                throw new Exception("Kapacita kurzu je již naplněna.");
            if (!exist)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                Registrations.Add(registration);
            }
            else
            {
                throw new Exception("Uživatel je v kurzu již registrovaný.");
            }
        }
        /// <summary>
        /// Odtraňuje konkrétní registraci z databáze
        /// </summary>
        /// <param name="registration"></param>
        public void RemoveStudenFromCourse(Registration registration)
        {
            db.Registrations.Remove(db.Registrations.First(r => r.CourseId == registration.CourseId && r.UserId == registration.UserId));
            db.SaveChanges();
            Registrations.Remove(registration);
        }

        public ObservableCollection<Classification> ClassificationOfStudentInCourse(Course course, User user)
        {
            ObservableCollection<Classification> classifications = new ObservableCollection<Classification>();
            foreach (Classification cl in Classifications)
            {
                if ((cl.CourseId == course.Id) && (cl.UserId == user.Id))
                {
                    classifications.Add(cl);
                }                
            }
            return classifications;
        }

        public void AddClassification(Classification classification)
        {
            db.Classifications.Add(classification);
            db.SaveChanges();
            Classifications.Add(classification);
        }

        public void RemoveClassification(Classification classification)
        {            
            db.Classifications.Remove(db.Classifications.First(cl => cl.Id == classification.Id));
            db.SaveChanges();
            Classifications.Remove(classification);
        }

        public ObservableCollection<Course> CoursesByUser(User user)
        {
            ObservableCollection<Course> courses = new ObservableCollection<Course>();
            foreach (Registration r in Registrations)
            {
                if (r.UserId == user.Id)
                {
                    courses.Add(r.Course);
                }
            }
            return courses;
        }

        public bool IsUserRegistered(Course course, User user)
        {
            bool registered = false;
            foreach (Registration r in Registrations)
            {
                if ((r.CourseId == course.Id) && (r.UserId == user.Id))               
                    registered = true;                            
            }
            return registered;
        }

        public void RemoveAllClassicationOfStudentInCourse(Course course, User user)
        {
            db.Classifications.RemoveRange(ClassificationOfStudentInCourse(course, user));
            db.SaveChanges();
            ObservableCollection<Classification> classifications = Classifications;
            foreach (Classification cl in classifications)
            {
                if ((cl.CourseId == course.Id) && (cl.UserId == user.Id))
                {
                    Classifications.Remove(cl);
                }                
            }            
        }
    }
}
