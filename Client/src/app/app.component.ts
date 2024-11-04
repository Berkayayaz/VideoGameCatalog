// src/app/app.component.ts
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, CommonModule],
  template: `
    <div class="container">
      <nav class="navbar navbar-expand-lg navbar-light bg-light mb-4">
        <div class="container-fluid">
          <a class="navbar-brand" routerLink="/">Video Game Catalog</a>
        </div>
      </nav>
      <router-outlet></router-outlet>
    </div>
  `
})
export class AppComponent {
  title = 'video-game-catalog';
}