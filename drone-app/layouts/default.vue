<template>
  <v-app>
    <v-navigation-drawer
      v-model="drawer"
      floating
      mini-variant
      temporary
      app
      overflow
    >
      <v-list dense>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-qrcode-scan</v-icon>
          </v-list-item-action>
        </v-list-item>

        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-package-variant-closed</v-icon>
          </v-list-item-action>
        </v-list-item>

        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-logout</v-icon>
          </v-list-item-action>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar
      clipped-left
      app
    >
      <v-app-bar-nav-icon
        @click.stop="drawer = !drawer"
      />
      <v-toolbar-title>Drone App</v-toolbar-title>
    </v-app-bar>

    <v-content>
      <nuxt />
    </v-content>

    <v-footer
      app
    >
      <span class="px-4">&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
        drawer: false,
    }),
  }
</script>

