// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { GameCatalogComponent } from './components/game-catalog/game-catalog.component';
import { GameEditComponent } from './components/game-edit/game-edit.component';

export const routes: Routes = [
  { path: '', component: GameCatalogComponent },
  { path: 'edit/:id', component: GameEditComponent }
];