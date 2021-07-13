import { HostListener, OnDestroy } from '@angular/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnDestroy {
  loggedIn: boolean;
  loginbuttonText: string="LogIn";
  constructor(private route: Router) {
    localStorage.getItem("loggedIn") === 'YES' ? this.loggedIn = true : this.loggedIn = false;
  }
    ngOnDestroy(): void {
      localStorage.removeItem('loggedIn');
    }
  login() {
    if (this.loggedIn) {
      this.loggedIn = false;
      this.loginbuttonText = "Login";
      localStorage.removeItem('loggedIn');
      this.route.navigate(['/']);
    }
    else {
      this.route.navigate(['/workorder-info']);
      this.loggedIn = true;
      this.loginbuttonText = "Logout";
      localStorage.setItem("loggedIn", "YES");
    }

  }
  @HostListener('window:beforeunload', ['$event'])
  onWindowClose(event: any): void {
    localStorage.removeItem('loggedIn');

  }
}
