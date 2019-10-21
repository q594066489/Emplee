$(function(){ 
     var  input={
          education:'',
          salary:'',
          experience:'',
          scale:'',
          finance:'',
          SetValueByClass:function (_class,_value){
               switch(_class){
                   case 'education':
                       if(_value!=null){
                            this.education=_value;
                       }
                       break;
                    case 'salary':
                        if(_value!=null){
                            this.salary=_value;
                        }
                        break;
                    case 'experience':
                       if(_value!=null){
                            this.experience=_value;
                       }
                       break;   
                    case 'scale':
                        if(_value!=null){
                            this.scale=_value;
                        }
                        break;  
                    case 'finance':
                            if(_value!=null){
                                this.finance=_value;
                            }
                        break; 
                    default:
                        break;
               }
          }
     }
    //  function SetValueByClass(_class,_value){
    //         switch

    //  }
     $(".divbtn").click(function(){

        $(this).siblings().removeClass('divclick');
        $(this).addClass('divclick');
        console.log('class:---')
        console.log($(this).attr('data-class'));
        console.log('value:---')
        console.log($(this).attr('data-value'));
        input.SetValueByClass($(this).attr('data-class'),$(this).attr('data-value'));
        
        console.log(input);


     })


}); 
    
     