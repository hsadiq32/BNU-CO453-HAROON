if(Request.Files["UploadedFile"] != null)
{
    HttpPostedFile MyFile = Request.Files["UploadedFile"];
    //Setting location to upload files
    string TargetLocation = Server.MapPath("~/Files/");
    try
    {
        if (MyFile.ContentLength > 0)
        {
            //Determining file name. You can format it as you wish.
            string FileName = MyFile.FileName;
            //Determining file size.
            int FileSize = MyFile.ContentLength;
            //Creating a byte array corresponding to file size.
            byte[] FileByteArray = new byte[FileSize];
            //Posted file is being pushed into byte array.
            MyFile.InputStream.Read(FileByteArray, 0, FileSize);
            //Uploading properly formatted file to server.
            MyFile.SaveAs(TargetLocation + FileName);
        }
    }
    catch(Exception BlueScreen)
    {
        //Handle errors
    }
}