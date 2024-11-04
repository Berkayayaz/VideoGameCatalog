// src/app/services/video-game.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface VideoGame {
  id: number;
  title: string;
  developer: string;
  publisher: string;
  releaseDate: Date;
  genre: string;
  price: number;
  description: string;
  rating: number;
}

@Injectable({
  providedIn: 'root'
})
export class VideoGameService {
  private apiUrl = 'http://localhost:5129/api/VideoGame'; // Changed to HTTP and your port

  constructor(private http: HttpClient) { }

  getGames(): Observable<VideoGame[]> {
    return this.http.get<VideoGame[]>(this.apiUrl);
  }

  getGame(id: number): Observable<VideoGame> {
    return this.http.get<VideoGame>(`${this.apiUrl}/${id}`);
  }

  updateGame(id: number, game: VideoGame): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, game);
  }

  createGame(game: VideoGame): Observable<VideoGame> {
    return this.http.post<VideoGame>(this.apiUrl, game);
  }
}