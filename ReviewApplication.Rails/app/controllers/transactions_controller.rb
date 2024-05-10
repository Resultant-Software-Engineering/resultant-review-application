class TransactionsController < ApplicationController
  before_action :set_user_and_bank_account

  def new
    @transaction = Transaction.new(amount: params[:amount], kind: params[:kind],)
    @amount = params[:amount]
  end

  def create



    @user = User.find_by(email: params[:username])

    if @user
      @transaction = @user.bank_account.transactions.build(transaction_params)
      if @transaction.save
        update_balance
        flash[:notice] = 'Transaction was successfully created.'
        redirect_to bank_account_path(@user.bank_account, username: params[:username])
      else
        flash[:alert] = 'Failed to create transaction.'
        redirect_to bank_account_path(@user.bank_account, username: params[:username])
      end
    else
      render json: { success: false, errors: ['User not found'] }
    end
  end

  private

  def transaction_params
    params.permit(:amount, :kind)
  end

  def set_user_and_bank_account
    @user = User.find_by(email: params[:username])
    @bank_account = @user.bank_account if @user
  end

  def update_balance
    if @transaction.kind == 'deposit'
      @bank_account.increment!(:balance, @transaction.amount.to_f)
    elsif @transaction.kind == 'withdrawal'
      @bank_account.decrement!(:balance, @transaction.amount.to_f)
    end
  end
end