using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TeamApiProject.Data.Entities.Enums;

public enum LikeAction
{
    [Description("Liked")]
    Like =1,

    [Description("Disliked")]
    Disliked
}