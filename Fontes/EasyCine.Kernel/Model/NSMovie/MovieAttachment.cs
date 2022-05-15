//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSMovie
{
	[Table("MovieAttachments")]
	public sealed class MovieAttachment
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_movie_attachment", TypeName = "BIGINT")] public long MovieAttachmentId { get; set; } 
		[Column("ds_url", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string Url { get; set; } 
		[Column("id_attachment_type", TypeName = "INT"), Required] public AttachmentType AttachmentType { get; set; }
		[Column("MovieId", TypeName = "BIGINT"), ForeignKey("Movie")] public long MovieId { get; set; } 
		public Movie Movie { get; set; } 

		public MovieAttachment() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().MovieAttachmentSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}