// src/app/components/game-catalog/game-catalog.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { VideoGameService, VideoGame } from '../../services/video-game.service';

@Component({
  selector: 'app-game-catalog',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <div class="container mt-4">
      <div class="d-flex justify-content-between align-items-center mb-4">
        <h2>Video Game Catalog</h2>
        <a routerLink="/edit/new" class="btn btn-success">Add New Game</a>
      </div>
      
      <div class="row">
        <div class="col-md-4 mb-3" *ngFor="let game of games">
          <div class="card h-100">
            <div class="card-body">
              <h5 class="card-title">{{game.title}}</h5>
              <h6 class="card-subtitle mb-2 text-muted">{{game.publisher}}</h6>
              <p class="card-text">{{game.description}}</p>
              <div class="card-text mb-2">
                <small class="text-muted">
                  Developer: {{game.developer}}<br>
                  Genre: {{game.genre}}<br>
                  Price: {{game.price | currency}}<br>
                  Rating: {{game.rating}}/5
                </small>
              </div>
              <p class="card-text">
                <small class="text-muted">
                  Released: {{game.releaseDate | date}}
                </small>
              </p>
              <a [routerLink]="['/edit', game.id]" class="btn btn-primary">Edit</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  `
})
export class GameCatalogComponent implements OnInit {
  games: VideoGame[] = [];

  constructor(private gameService: VideoGameService) {}

  ngOnInit() {
    this.gameService.getGames().subscribe({
      next: (games) => this.games = games,
      error: (error) => console.error('Error fetching games:', error)
    });
  }
}