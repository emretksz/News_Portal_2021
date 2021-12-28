////< !--KATEGORİLERE İD VERECEĞİM URL VERİP HER TIKLANDIĞINDA O ACTİONA GİDİP SSAYFAYUA BASILSIN-- >

////@section Scripts{

////    @*<script>
////        function CategoriGetir(CategoryId) {

////            $.ajax({

////                url: '/Home/Filtre',
////                method: "GET",
////                data: { CategoryId },

////                success: function (data) {
////                    $('#BlogList').html(data);
////                },
////                error: function (data) {
////                    alert("Blog Bulunamadı...")
////                }

////            })
////        }

        
////        //$('#getir').click(function () {

////        //    var id = $(this).parent().children().text();
////        //    var category = $(this).parent().children().attr();

////        //    $.ajax({

////        //        url: '/Home/Filtre',
////        //        method: "GET",
////        //        data: {id, category},
////        //        success: function (data) {
////        //            $('#BlogList').html(data);
////        //        },
////        //        error: function (data) {
////        //            alert("Blog Bulunamadı...")
////        //        }

////        //    })

////        //});


////    </script>
////        <script>
////            $(document).ready(function () {
////                $('pagination.age-item li').click(function (e) {
////                    alert($(this).find("a.page-link").text());
////                });
////        });
////        </script> *@

        $('.btn-reply').click(function () {

            var GuestId = $(this).parent().children('p').attr('id');
            var GuestName = $(this).parent().children('p').text();

            $('#yorumId').html(GuestId);
            $('#Kime').removeAttr('hidden');
            $('#yorumYapılan') .removeAttr('hidden');
            $('#yorumYapılan').html(GuestName);
            $('#vazgec').removeAttr('hidden');

        });


        $('#vazgec').click(function () {


            $('#yorumId').html();
            $('#Kime').attr('hidden','hidden');
            $('#yorumYapılan').html();
            $('#yorumYapılan').attr('hidden', 'hidden');
            $('#vazgec').attr('hidden','hidden');

        });

  


    

        $('.button-contactForm').click(function () {
            var MdmId = $('#MdmId').val();
            var userId = $('#userId').val();
            var comment = $('#comment').val();
            var name = $('#name').val();
            var email = $('#email').val();
            var IsReply = $('#yorumId').text();

            $.ajax({

                url: '/Home/CommentAdd',
                method: 'POST',
                async: false,
                data: { MdmId, userId,comment, name, email,IsReply },
                success: function (data) {
                    $('.comment-list').html(data);
                },
                error: function (data) {
                    alert("Yorum Yapılamadı");
                }

            })
        });
       

  