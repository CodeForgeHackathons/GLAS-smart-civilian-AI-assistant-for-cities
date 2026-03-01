import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import { logger } from '@/utils/logger'

type AuthUser = {
  accountId: number
  firstName: string
  lastName: string
  phoneNumber: string
  birthDate: string
}

const TOKEN_KEY = 'glas_auth_token'
const USER_KEY = 'glas_auth_user'

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5024/api'

export const useAuthStore = defineStore('auth', () => {
  const token = ref<string | null>(localStorage.getItem(TOKEN_KEY))
  const user = ref<AuthUser | null>(null)

  const savedUser = localStorage.getItem(USER_KEY)
  if (savedUser) {
    try {
      user.value = JSON.parse(savedUser) as AuthUser
    } catch {
      localStorage.removeItem(USER_KEY)
    }
  }

  const isAuthenticated = computed(() => !!token.value)

  async function login(phoneNumber: string, password: string) {
    logger.log('auth:login:start', { phoneNumber })

    const response = await fetch(`${API_BASE_URL}/user/login`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        phoneNumber,
        password,
      }),
    })

    if (!response.ok) {
      const message = await response.text()
      logger.error('auth:login:failed', { phoneNumber, status: response.status, message })
      throw new Error(message || 'Failed to login')
    }

    const data = (await response.json()) as {
      accountID: number
      firstName: string
      lastName: string
      phoneNumber: string
      birthDate: string
      token: string
    }

    token.value = data.token
    user.value = {
      accountId: data.accountID,
      firstName: data.firstName,
      lastName: data.lastName,
      phoneNumber: data.phoneNumber,
      birthDate: data.birthDate,
    }

    localStorage.setItem(TOKEN_KEY, data.token)
    localStorage.setItem(USER_KEY, JSON.stringify(user.value))

    logger.log('auth:login:success', { accountId: data.accountID, phoneNumber: data.phoneNumber })
  }

  function logout() {
    logger.log('auth:logout', { accountId: user.value?.accountId, phoneNumber: user.value?.phoneNumber })
    token.value = null
    user.value = null
    localStorage.removeItem(TOKEN_KEY)
    localStorage.removeItem(USER_KEY)
  }

  function getAuthHeaders() {
    if (!token.value) return {}
    return {
      Authorization: `Bearer ${token.value}`,
    }
  }

  return {
    token,
    user,
    isAuthenticated,
    login,
    logout,
    getAuthHeaders,
  }
})

