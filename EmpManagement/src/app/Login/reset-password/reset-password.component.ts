import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/shared/login.service';
import { ResetPassword } from 'src/app/shared/ResetPassword.model';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  resetPassword:ResetPassword;

  constructor(private loginService:LoginService,private router:Router) { }

  ngOnInit(): void {
    this.resetPassword=this.InitializeResetpassword();
  }

  ResetPassword(resetpassword:ResetPassword){
    this.loginService.ResetPassword(resetpassword).subscribe(
      next =>{
        console.log("Password successfully changed");
        this.router.navigate(['/login']);
      }
    )

  }

  private InitializeResetpassword():ResetPassword{
    return{
      Email:'',
      Password:'',
      ConfirmPassword:''
    }
  }

}
