import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../core/services/auth/auth';
import { HlmButtonImports } from '@spartan-ng/helm/button';
import { ThemeService } from '../../../core/services/theme/theme';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header.html',
  styleUrls: ['./header.scss']
})
export class HeaderComponent {
  constructor(public themeService: ThemeService) {}
  authService = inject(AuthService);
  router = inject(Router);

  // Expondo o signal de autenticação diretamente para o template
  isAuthenticated = this.authService.isAuthenticated;
  currentUser = this.authService.currentUser;

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/auth/login']);
  }
}
