using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApp.Model
{
    public class Note
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid Id { get; set; }
        public string ImgSrc { get; set; }
        public IdentityUser User { get; set; }


        public void SetId()
        {
            Id = Guid.NewGuid();
        }
        public void SetImgSrc()
        {
            ImgSrc = "https://avatars.dicebear.com/v2/identicon/" + Id.ToString() + ".svg";
        }
    }
}
