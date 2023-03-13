using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.AspNetCore;
using CMSPlus.Domain.Models.TopicModels;
using CMSPlus.Domain.Persistance;


namespace CMSPlus.Presentation.Controllers;

public class CommentController : Controller
{
    private readonly ApplicationDbContext _db;

    [BindProperty]
    public CommentModel comment { get; set; }

    public CommentController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert()
    {
       // comment = new CommentModel();
        if (ModelState.IsValid)
        {
            if (comment.Id == 0)
            {
                _db.Set<CommentModel>().Add(comment);

            }
            _db.SaveChanges();
        }
        return View();
    }


    public IActionResult Upsert(int? id)
    {
        // comment = new CommentModel();
        if (ModelState.IsValid)
        {
            if (comment.Id == 0)
            {
                _db.Set<CommentModel>().Add(comment);

            }
            _db.SaveChanges();
        }
        return View();
    }




}

