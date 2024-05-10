Rails.application.routes.draw do
  get 'users/new'
  get 'users/create'
  get 'transactions/new'
  get 'transactions/create'
  get 'sessions/new'
  get 'sessions/create'
  get 'sessions/destroy'
  get 'bank_accounts/show'
  # Define your application routes per the DSL in https://guides.rubyonrails.org/routing.html

  # Reveal health status on /up that returns 200 if the app boots with no exceptions, otherwise 500.
  # Can be used by load balancers and uptime monitors to verify that the app is live.
  get "up" => "rails/health#show", as: :rails_health_check

  resources :sessions, only: [:new, :create, :destroy]
  resources :bank_accounts, only: [:show]
  resources :transactions, only: [:new, :create]
  resources :users, only: [:new, :create]
  root 'sessions#new'
  # Defines the root path route ("/")
  # root "posts#index"
end