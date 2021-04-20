using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CO453_WebApps.Data;
using CO453_WebApps.Models;

namespace CO453_WebApps.Controllers
{
    public class MessagePostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagePostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MessagePosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Messages.ToListAsync());
        }

        // GET: PhotoPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messagePost = await _context.Messages
                .Include(c => c.Comments)
                .FirstOrDefaultAsync(m => m.PostID == id);


            if (messagePost == null)
            {
                return NotFound();
            }

            return View(messagePost);
        }

        // GET: MessagePosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MessagePosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Message,PostID,Username")] MessagePost messagePost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(messagePost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(messagePost);
        }

        // GET: MessagePosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messagePost = await _context.Messages.FindAsync(id);
            if (messagePost == null)
            {
                return NotFound();
            }
            return View(messagePost);
        }

        // POST: MessagePosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Message,PostID,Username")] MessagePost messagePost)
        {
            if (id != messagePost.PostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(messagePost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessagePostExists(messagePost.PostID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(messagePost);
        }

        // GET: MessagePosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messagePost = await _context.Messages
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (messagePost == null)
            {
                return NotFound();
            }

            return View(messagePost);
        }

        // POST: MessagePosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var messagePost = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(messagePost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Like(int id)
        {
            var messagePost = _context.Messages.Find(id);

            if (messagePost == null)
            {
                return NotFound();
            }
            messagePost.Like();
            try
            {
                _context.Update(messagePost);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessagePostExists(messagePost.PostID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult Unlike(int id)
        {
            var messagePost = _context.Messages.Find(id);

            if (messagePost == null)
            {
                return NotFound();
            }
            messagePost.Unlike();
            try
            {
                _context.Update(messagePost);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessagePostExists(messagePost.PostID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", new { id = id });
        }

        private bool MessagePostExists(int id)
        {
            return _context.Messages.Any(e => e.PostID == id);
        }
    }
}
