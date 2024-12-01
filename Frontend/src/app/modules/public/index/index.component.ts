import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { FooterComponent } from '../../../core/components/footer/footer.component';

import { SignupComponent } from '../signup/signup.component';
import { LoginComponent } from '../login/login.component';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [RouterOutlet,FooterComponent,LoginComponent,SignupComponent,RouterLink,NavbarComponent,HeaderComponent],
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent {

}
