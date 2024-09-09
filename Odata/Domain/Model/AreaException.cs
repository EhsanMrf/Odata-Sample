using Utility.Exception;

namespace Domain.Model;

public class AreaException
{
    public class AreaTitleInvalid() : BaseException("Ex1004D01", "عنوان معتبر نمیباشد");
    public class AreaCodeInvalid() : BaseException("Ex1004D02", "کد معتبر نمیباشد" );

}