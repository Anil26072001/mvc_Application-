var UploadFileVariable = {
    FileInput: "#fileInput",
    Filename: "#filename",
    IconErrorMsg: "#ErrorfileIcons",
    FileErrorMsg: "#Errormesssagefile",
    BtnUpload: "#btnuploadfileId",
    ErrorMsgbtn: "#Errormessagebutton",
    BootstrapAlert: "#BootStrapErroMsg",
    BtnReplaceFile: "#replaceFileBtn",
    BtnSaveNewVersion: "#saveNewVersionBtn",
    BtnCancel: "#Cancelbtn"
};

$(document).ready(function () {

    $('#Cancelbtn').on('click', function () {

        $('#fileExistsPopup').modal('hide');
         console.log("btn click");

    });
    $(UploadFileVariable.IconErrorMsg).hide();
    $(UploadFileVariable.FileInput).on('change', function (event) {
        var FileValue = $(UploadFileVariable.FileInput).val();
        if (FileValue != '') {
            $(UploadFileVariable.BootstrapAlert).hide();
        }
    });

    $(UploadFileVariable.BtnUpload).click(function () {

        var Cheakfiles = $(UploadFileVariable.FileInput)[0].files;
        var FileValue = $(UploadFileVariable.FileInput).val();
        var IsValid = true;
        //checking file is available or not
        if (FileValue == '') {
            $(UploadFileVariable.FileErrorMsg).text('Plese Select File').show();
            $(UploadFileVariable.IconErrorMsg).show();
            $(UploadFileVariable.BootstrapAlert).show();
            IsValid = false;
            return false;
        }
        //Checking File Formate 

        var RegExpression = /\.(jpg|png|ppt|pdf|doc|docx|xls|xlsx)$/i;
        if (!RegExpression.test(FileValue)) {
            $(UploadFileVariable.BootstrapAlert).show();
            $(UploadFileVariable.FileErrorMsg).text('Invalid file format.Allowed formats are: .jpg, .png, .ppt, .pdf, .doc, .docx, .xls, .xlsx').show();
            $(UploadFileVariable.IconErrorMsg).show();
            IsValid = false;

        }

        console.log(Cheakfiles);
        if (IsValid) {
            var FileInput = $(UploadFileVariable.FileInput)[0]; // Replace 'fileId' with the actual id of your file input element

            var formData = new FormData();
            var Allfiles = FileInput.files;



            for (let i = 0; i < Allfiles.length; i++) {
                formData.append("file", Allfiles[i]);
                CheckingExistingFileOrNot(Allfiles[i].name, formData);
            }

            // uploadFiles(Uploadfiles);
        }
    });
});

//File Checking
function CheckingExistingFileOrNot(filename, formData) {

    $.ajax({

        type: 'Get',
        url: 'FileController1/FileChecking?fileName=' + filename,

        success: function (result) {
            console.log(result);
            if (result.fileExists) {
                $('#fileExistsPopup').modal('show');
            }
            else {
                uploadFiles(formData);
            }

        },
        error: function (xhr, status, error) {

        }

    });
}
$(UploadFileVariable.BtnReplaceFile).on('click', function () {
    console.log("Click");
    var FileInput = $(UploadFileVariable.FileInput)[0];
    var formdata = new FormData();
    var allfile = FileInput.files;
    for (var i = 0; i < allfile.length; i++) {
        formdata.append("file", allfile[i]);
    }
    uploadFiles(formdata);
});



function uploadFiles(formdata) {



    $.ajax({
        url: 'FileController1/FileUpload',
        type: 'post',
        data: formdata,
        processData: false,
        contentType: false,
        success: function (data) {
            console.log(data);
            alert("File upload succussfully");
            $('#fileExistsPopup').modal('hide');
            window.location.href ='/FileController1/Listpage';
        },

        error: function (xhr, status, error) {
            console.error('Upload error:', error);
            $(UploadFileVariable.ErrorMsgbtn).text('Failed to upload files. Please try again later.');
        }
    });
   
}



