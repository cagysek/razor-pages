using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;
using AccountingApp.Services;
using AutoMapper;
using AccountingApp.Models.ViewModels;
using AccountingApp.Enum;

namespace AccountingApp.Pages.User
{
    /// <summary>
    /// PageModel for edit logged user
    /// </summary>
    public class EditModel : PageModel
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly DatabaseContext _context;

        /// <summary>
        /// Session service
        /// </summary>
        private readonly ISessionService _sessionService;

        /// <summary>
        /// Mapper service
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Binded property for view. Represents user edit
        /// </summary>
        [BindProperty]
        public UserEdit UserEdit { get; set; }

        public EditModel(DatabaseContext context, ISessionService _sessionService, IMapper mapper)
        {
            _context = context;
            this._sessionService = _sessionService;
            this.mapper = mapper;
        }

        /// <summary>
        /// GET action. Shows form for edit logged user
        /// </summary>
        /// <returns>Page with edit form for logged user</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            // get user id from session
            var id = this._sessionService.GetUserId();

            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUser
                                .Include(m => m.Address)
                                .Include(m => m.Role)
                                .FirstOrDefaultAsync(m => m.Id == id)
                                ;


            if (appUser == null)
            {
                return NotFound();
            }

            // map appUser to UserEdit
            UserEdit = this.mapper.Map<UserEdit>(appUser);

            return Page();
        }

        /// <summary>
        /// POST action. Process user edit form
        /// </summary>
        /// <returns>If process is without error, returns user detail, else returns current page with error</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // check if model is valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var appUser = new AppUser();

            // map userEdit back to AppUser
            appUser = this.mapper.Map<AppUser>(UserEdit);


            // check if username is not used
            if (!VerifyUsername(appUser.UserName, appUser.Id))
            {
                TempData[EFlashMessage.Error] = "Uživatelské jméno je již použito";

                return Page();
            }

            // mark objects for update
            _context.Attach(appUser).State = EntityState.Modified;
            _context.Attach(appUser.Address).State = EntityState.Modified;

            // exclude role and password property from update
            // user can not update own role
            // for change password exists different form
            _context.Entry(appUser).Property(x => x.Password).IsModified = false;
            _context.Entry(appUser).Reference(x => x.Role).IsModified = false;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(appUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData[EFlashMessage.Success] = "Uloženo";

            return RedirectToPage("/User/Details");
        }

        /// <summary>
        /// Check if user exists
        /// </summary>
        /// <param name="id">Id of user to check</param>
        /// <returns>TRUE if exists, else FALSE</returns>
        private bool AppUserExists(int id)
        {
            return _context.AppUser.Any(e => e.Id == id);
        }

        /// <summary>
        /// Check if username is not used
        /// </summary>
        /// <param name="username">username to check</param>
        /// <param name="userId">user id for exclude</param>
        /// <returns>TRUE if username is used, else FALSE</returns>
        public bool VerifyUsername(string username, int userId)
        {
            // try find user by username
            // added condition to exclude current user
            var user = _context.AppUser.Where(a => a.UserName == username).Where(a => a.Id != userId).FirstOrDefault();

            if (user != null)
            {
                return false;
            }

            return true;
        }

    }
}
