// src/app/components/game-edit/game-edit.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, FormsModule } from '@angular/forms';
import { VideoGameService, VideoGame } from '../../services/video-game.service';

@Component({
  selector: 'app-game-edit',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  template: `
    <div class="container mt-4">
      <h2>{{isNewGame ? 'Add New Game' : 'Edit Game'}}</h2>
      <form [formGroup]="gameForm" (ngSubmit)="onSubmit()" *ngIf="gameForm">
        <div class="mb-3">
          <label class="form-label">Title</label>
          <input type="text" class="form-control" formControlName="title">
        </div>
        
        <div class="mb-3">
          <label class="form-label">Developer</label>
          <input type="text" class="form-control" formControlName="developer">
        </div>

        <div class="mb-3">
          <label class="form-label">Publisher</label>
          <input type="text" class="form-control" formControlName="publisher">
        </div>

        <div class="mb-3">
          <label class="form-label">Genre</label>
          <input type="text" class="form-control" formControlName="genre">
        </div>

        <div class="mb-3">
          <label class="form-label">Price</label>
          <input type="number" class="form-control" formControlName="price">
        </div>

        <div class="mb-3">
          <label class="form-label">Description</label>
          <textarea class="form-control" formControlName="description" rows="3"></textarea>
        </div>

        <div class="mb-3">
          <label class="form-label">Release Date</label>
          <input type="date" class="form-control" formControlName="releaseDate">
        </div>

        <div class="mb-3">
          <label class="form-label">Rating (0-5)</label>
          <input type="number" class="form-control" formControlName="rating" min="0" max="5" step="0.1">
        </div>

        <button type="submit" class="btn btn-primary" [disabled]="!gameForm.valid">Save</button>
        <button type="button" class="btn btn-secondary ms-2" (click)="goBack()">Cancel</button>
      </form>
    </div>
  `
})
export class GameEditComponent implements OnInit {
  gameForm: FormGroup;
  gameId: number = 0;
  isNewGame: boolean = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private gameService: VideoGameService
  ) {
    this.gameForm = this.fb.group({
      title: ['', Validators.required],
      developer: ['', Validators.required],
      publisher: ['', Validators.required],
      genre: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      description: [''],
      releaseDate: ['', Validators.required],
      rating: [0, [Validators.required, Validators.min(0), Validators.max(5)]]
    });
  }

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    this.isNewGame = idParam === 'new';

    if (!this.isNewGame && idParam) {
      this.gameId = +idParam;
      this.gameService.getGame(this.gameId).subscribe({
        next: (game) => {
          this.gameForm.patchValue({
            ...game,
            releaseDate: new Date(game.releaseDate).toISOString().split('T')[0]
          });
        },
        error: (error) => {
          console.error('Error loading game:', error);
          this.router.navigate(['']);
        }
      });
    }
  }

  onSubmit(): void {
    if (this.gameForm.valid) {
      const game = {
        ...this.gameForm.value,
        id: this.isNewGame ? 0 : this.gameId
      };

      if (this.isNewGame) {
        this.gameService.createGame(game).subscribe({
          next: () => this.router.navigate(['']),
          error: (error) => console.error('Error creating game:', error)
        });
      } else {
        this.gameService.updateGame(this.gameId, game).subscribe({
          next: () => this.router.navigate(['']),
          error: (error) => console.error('Error updating game:', error)
        });
      }
    }
  }

  goBack(): void {
    this.router.navigate(['']);
  }
}